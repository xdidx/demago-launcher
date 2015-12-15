using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace gta_demago_launcher
{
    public partial class Form1 : Form
    {
        private string gtaInstallationPath = "";
        private string checkingFileName = "GTA5.exe";
        private string backupFolderName = "gta-demago-backup/";
        private string scriptFolderName = "scripts/";
        private string scriptName = "DemagoScript.dll";
        private WsVersionResponse versionResponse = null;

        private string[] modFiles = { "ScriptHookVDotNet.dll", "ScriptHookV.dll", "dinput8.dll", "OpenIV.asi", "ScriptHookVDotNet.asi" };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> defaultPaths = new List<string> { "C:/Program Files/Rockstar Games/Grand Theft Auto V/", "C:/Program Files (x86)/Steam/steamapps/common/" };
            foreach (string path in defaultPaths)
            {
                if (File.Exists(path + checkingFileName))
                {
                    gtaInstallationPath = path;
                    break;
                }
            }

            checkModVersion();
        }

        private void B_chooseGtaFile_Click(object sender, EventArgs e)
        {
            gtaLauncherFileDialog.ShowDialog();
            if (gtaLauncherFileDialog.FileName != "")
            {
                if (File.Exists(gtaLauncherFileDialog.FileName))
                {
                    gtaInstallationPath = Path.GetDirectoryName(gtaLauncherFileDialog.FileName) + "\\";
                }
            }

            checkModVersion();
        }

        private bool checkInstallationPath()
        {
            if (gtaInstallationPath != "" && File.Exists(gtaInstallationPath + checkingFileName))
            {
                L_gtaInstallationPath.Text = gtaInstallationPath;
                B_chooseGtaFile.Text = "Modifier l'emplacement d'installation";
                return true;
            }
            else
            {
                L_gtaInstallationPath.Text = "Le fichier " + checkingFileName + " n\'a pas été trouvé";
                B_chooseGtaFile.Text = "Selectionner le fichier";
                L_state.Text = "GTA V non localisé";
            }

            return false;
        }

        private string getScriptLocation()
        {
            string scriptLocation = "";
            if (checkInstallationPath()) {
                scriptLocation = gtaInstallationPath + scriptFolderName + scriptName;
                if (!File.Exists(scriptLocation))
                {
                    scriptLocation = gtaInstallationPath + backupFolderName + scriptName;
                    if (!File.Exists(scriptLocation))
                    {
                        scriptLocation = "";
                    }
                }
            }
            return scriptLocation;
        }

        private bool checkModVersion()
        {
            scriptExists();

            L_modVersion.Text = "?";
            string modFileHash = getModFileHash();
            if (modFileHash == "")
            {
                L_state.Text = "Mod non installé";
            }
            else
            {
                B_update_mod.Enabled = true;
                versionResponse = DemagoWebService.checkCurrentVersion(modFileHash);
                if (versionResponse == null)
                {
                    L_state.Text = "Problème de connexion...";
                    B_update_mod.Enabled = false;
                }
                else
                {
                    if (versionResponse.error == "1")
                    {
                        L_state.Text = versionResponse.message;
                        B_update_mod.Enabled = false;
                    }
                    else
                    {
                        if (versionResponse.maxVersion > versionResponse.version)
                        {
                            L_state.Text = "Une mise a jour du mod est disponible";
                            B_update_mod.Text = "Mettre à jour vers la version " + versionResponse.maxVersion;
                        }
                        else if (versionResponse.maxVersion == versionResponse.version)
                        {
                            B_update_mod.Enabled = false;
                        }

                        L_modVersion.Text = versionResponse.version.ToString();
                        return true;
                    }
                }
            }

            return false;
        }

        private string getModFileHash()
        {
            string scriptLocation = getScriptLocation();
            if (File.Exists(scriptLocation))
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(scriptLocation))
                    {
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                    }
                }
            }
            return "";
        }

        private bool scriptExists()
        {
            string defaultScriptLocation = gtaInstallationPath + scriptFolderName + scriptName;
            string defaultBackupLocation = gtaInstallationPath + backupFolderName + scriptName;

            B_desactivate.Enabled = true;
            B_desactivate.Visible = true;

            if (getScriptLocation() == defaultScriptLocation)
            {
                B_desactivate.Text = "Désactiver le mod";
                return true;
            }
            else if (getScriptLocation() == defaultBackupLocation)
            {
                B_desactivate.Text = "Activer le mod";
                return true;
            }
            else
            {
                B_desactivate.Enabled = false;
            }
            return false;
        }

        private void B_desactivate_Click(object sender, EventArgs e)
        {
            if (scriptExists())
            {
                bool inBackupFolder = false, 
                    inScriptFolder = false;
                string defaultBackupLocation = gtaInstallationPath + backupFolderName + scriptName;
                string defaultScriptLocation = gtaInstallationPath + scriptFolderName + scriptName;
                if (getScriptLocation() == defaultScriptLocation)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(defaultBackupLocation)))
                        Directory.CreateDirectory(Path.GetDirectoryName(defaultBackupLocation));

                    File.Move(defaultScriptLocation, defaultBackupLocation);

                    inScriptFolder = true;
                }
                else if (getScriptLocation().StartsWith(gtaInstallationPath + backupFolderName))
                {
                    File.Move(defaultBackupLocation, defaultScriptLocation);
                    inBackupFolder = true;
                }

                foreach (string file in modFiles)
                {
                    string currentFileLocation = gtaInstallationPath + file;
                    string currentFileBackupLocation = gtaInstallationPath + backupFolderName + file;
                    if (inScriptFolder)
                    {
                        File.Move(currentFileLocation, currentFileBackupLocation);
                    }
                    else if (inBackupFolder)
                    {
                        File.Move(currentFileBackupLocation, currentFileLocation);
                    }
                }
            }

            scriptExists();
        }
        
        private void B_update_mod_Click(object sender, EventArgs clickEvent)
        {

            versionResponse = DemagoWebService.checkCurrentVersion(getModFileHash());
            if (versionResponse != null && (versionResponse.maxVersion > versionResponse.version || versionResponse.version == 0) && versionResponse.maxVersionDownloadLink != "")
            {
                var texturesLink = "";
                if (CB_withTextures.Checked && versionResponse.maxVersionTexturesLink != "")
                {
                    texturesLink = versionResponse.maxVersionTexturesLink;
                }
                downloadAndExtract(versionResponse.maxVersionDownloadLink, texturesLink);
                L_state.Text = "Téléchargement du mod en cours...";
            }
        }

        private void downloadAndExtract (string link, string secondLink = "")
        {
            using (WebClient wc = new WebClient())
            {
                string tempZipPath = gtaInstallationPath + "temp.zip";

                wc.DownloadProgressChanged += (object senderb, DownloadProgressChangedEventArgs e) =>
                {
                    PB_modDownload.Value = e.ProgressPercentage;
                };
                wc.DownloadFileCompleted += (object senderb, AsyncCompletedEventArgs e) =>
                {
                    ZipFile.ExtractToDirectory(tempZipPath, gtaInstallationPath);
                    File.Delete(tempZipPath);
                    checkModVersion();
                    if (secondLink != "")
                    {
                        downloadAndExtract(secondLink);
                        L_state.Text = "Téléchargement des textures en cours...";
                    }
                };

                wc.DownloadFileAsync(new System.Uri(versionResponse.maxVersionDownloadLink), tempZipPath);
            }
        }

        private void B_playGTA_Click(object sender, EventArgs e)
        {

        }
    }
}
