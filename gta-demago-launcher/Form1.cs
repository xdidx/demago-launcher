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

namespace gta_demago_launcher
{
    public partial class Form1 : Form
    {
        private string gtaInstallationPath = "";
        private string checkingFileName = "GTA5.exe";
        private string backupFolderName = "gta-demago-backup/";
        private string scriptFolderName = "scripts/";
        private string scriptName = "DemagoScript.dll";

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
                L_modVersion.Text = "GTA V non localisé";
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

            string scriptLocation = getScriptLocation();
            if (File.Exists(scriptLocation))
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(scriptLocation))
                    {
                        string modFileHash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                        WsVersionResponse response = DemagoWebService.checkCurrentVersion(modFileHash);
                        if (response == null)
                        {
                            L_modVersion.Text = "Problème de connexion...";
                        }
                        else
                        {
                            if (response.error == "1")
                            {
                                L_modVersion.Text = response.message;
                            }
                            else
                            {
                                if (response.maxVersion > response.version)
                                {
                                    MessageBox.Show("Une nouvelle version est disponible : " + response.maxVersion);
                                }
                                L_modVersion.Text = response.version.ToString() ;
                                return true;
                            }
                        }
                    }
                }
            }
            else
            {
                L_modVersion.Text = "Non installé";
            }

            return false;
        }

        private void scriptExists()
        {
            string defaultScriptLocation = gtaInstallationPath + scriptFolderName + scriptName;
            string defaultBackupLocation = gtaInstallationPath + backupFolderName + scriptName;

            B_desactivate.Enabled = true;
            B_desactivate.Visible = true;

            if (getScriptLocation() == defaultScriptLocation)
            {
                B_desactivate.Text = "Désactiver le mod";
            }
            else if (getScriptLocation() == defaultBackupLocation)
            {
                B_desactivate.Text = "Activer le mod";
            }
            else
            {
                B_desactivate.Visible = false;
                B_desactivate.Enabled = false;
            }
        }

        private void B_desactivate_Click(object sender, EventArgs e)
        {
            if (checkModVersion())
            {
                string defaultScriptLocation = gtaInstallationPath + scriptFolderName + scriptName;
                string defaultBackupLocation = gtaInstallationPath + backupFolderName + scriptName;
                if (getScriptLocation() == defaultScriptLocation)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(defaultBackupLocation)))
                        Directory.CreateDirectory(Path.GetDirectoryName(defaultBackupLocation));

                    File.Move(defaultScriptLocation, defaultBackupLocation);
                }
                else if (getScriptLocation() == defaultBackupLocation)
                {
                    File.Move(defaultBackupLocation, defaultScriptLocation);
                }
            }

            scriptExists();
        }
    }
}
