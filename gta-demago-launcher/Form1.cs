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
        private string checkingFileName = "GTAVLauncher.exe";
        private string backupFolderName = "gta-demago-backup/";
        private string scriptFolderName = "scripts/";
        private string scriptName = "DemagoScript.dll";
        private WsVersionResponse versionResponse = null;

        private string[] modFiles = { "ScriptHookVDotNet.dll",
                                            "ScriptHookV.dll",
                                                "dinput8.dll",
                                                 "OpenIV.asi",
                                      "ScriptHookVDotNet.asi",
                                  "scripts/irrKlang.NET4.dll" };

        public Form1()
        {
            InitializeComponent();
        }

        private void changeState(string message, Color color)
        {
            L_state.Text = message;
            L_state.ForeColor = color;
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
            this.B_desactivate.Enabled = scriptExists();
        }

        private void B_chooseGtaFile_Click(object sender, EventArgs e)
        {
            gtaLauncherFileDialog.ShowDialog();
            if (gtaLauncherFileDialog.FileName != "")
            {
                if (File.Exists(gtaLauncherFileDialog.FileName))
                {
                    gtaInstallationPath = Path.GetDirectoryName(gtaLauncherFileDialog.FileName) + "\\";
                    B_update_mod.Enabled = true;
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
                changeState("GTA V non localisé", Color.Black);
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
                    scriptLocation = gtaInstallationPath + backupFolderName + scriptFolderName + scriptName;
                    if (!File.Exists(scriptLocation))
                    {
                        scriptLocation = "";
                    }
                }
            }
            return scriptLocation;
        }

        private void checkModVersion()
        {
            L_modVersion.Text = "Inconnu";
            string modFileHash = getModFileHash();
            if (modFileHash != "")
            {
                B_update_mod.Enabled = true;
                versionResponse = DemagoWebService.checkCurrentVersion(modFileHash);
                if (versionResponse == null)
                {
                    changeState("Problème de connexion...", Color.Black);
                    B_update_mod.Enabled = false;
                }
                else
                {
                    if (versionResponse.error == "1")
                    {
                        changeState(versionResponse.message, Color.Red);
                        B_update_mod.Enabled = true;
                    }
                    else
                    {
                        if (versionResponse.maxVersion > versionResponse.version)
                        {
                            changeState("Une mise a jour du mod est disponible", Color.DarkRed);
                            B_update_mod.Text = "Mettre à jour vers la version " + versionResponse.maxVersion;
                            var updateMessageBox = MessageBox.Show("Votre version du mod n'est pas à jour. \nVoulez-vous télécharger le mod GTA Demago ?", "Le mod n'est pas à jour", MessageBoxButtons.YesNo);

                            if (updateMessageBox == DialogResult.Yes)
                            {
                                updateMod();
                            }
                        }
                        else if (versionResponse.maxVersion == versionResponse.version)
                        {
                            changeState("Le mod est à jour", Color.Black);
                            B_update_mod.Enabled = false;
                        }

                        L_modVersion.Text = versionResponse.version.ToString();
                    }
                }
            }
            else
            {
                changeState("Mod non installé", Color.Red);
                if (checkInstallationPath())
                {
                    var updateMessageBox = MessageBox.Show("Le mod n'est pas installé. \nVoulez-vous télécharger le mod GTA Demago ?", "Le mod n'est pas installé", MessageBoxButtons.YesNo);
                    if (updateMessageBox == DialogResult.Yes)
                    {
                        updateMod();
                    }
                }
                else
                {
                    var updateMessageBox = MessageBox.Show("Le jeu n'a pas été trouvé. \nVous devez sélectionner le repertoire d'installation pour lancer l'application", "Le jeu n'a pas été trouvé", MessageBoxButtons.OKCancel);
                    if (updateMessageBox == DialogResult.OK)
                    {
                        B_chooseGtaFile.PerformClick();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
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
            string defaultBackupLocation = gtaInstallationPath + backupFolderName + scriptFolderName + scriptName;

            //B_desactivate.Enabled = true;
            //B_desactivate.Visible = true;

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
                string defaultBackupLocation = gtaInstallationPath + backupFolderName + scriptFolderName + scriptName;
                string defaultScriptLocation = gtaInstallationPath + scriptFolderName + scriptName;
                if (getScriptLocation() == defaultScriptLocation)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(defaultBackupLocation))) { 
                        Directory.CreateDirectory(Path.GetDirectoryName(defaultBackupLocation));
                        Directory.CreateDirectory(Path.GetDirectoryName(defaultBackupLocation));

                    }

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
                    if (inScriptFolder && File.Exists(currentFileLocation))
                    {
                        File.Move(currentFileLocation, currentFileBackupLocation);
                    }
                    else if (inBackupFolder && File.Exists(currentFileBackupLocation))
                    {
                        File.Move(currentFileBackupLocation, currentFileLocation);
                    }
                }
            }

            scriptExists();
        }

        private void B_update_mod_Click(object sender, EventArgs clickEvent)
        {
            updateMod();
        }

        private void updateMod()
        {
            B_playGTA.Enabled = false;

            versionResponse = DemagoWebService.checkCurrentVersion(getModFileHash());
            if (versionResponse != null && (versionResponse.maxVersion > versionResponse.version || versionResponse.version == 0) && versionResponse.maxVersionDownloadLink != "")
            {
                changeState("Téléchargement du mod en cours...", Color.Black);
                List<string> toRemoveForMod = new List<string>(modFiles);
                toRemoveForMod.Add(scriptFolderName + scriptName);

                WebClient modWebClient = downloadAndExtract(versionResponse.maxVersionDownloadLink, toRemoveForMod.ToArray());
                modWebClient.DownloadFileCompleted += (object sender1, AsyncCompletedEventArgs e1) =>
                {
                    changeState("Téléchargement des musiques en cours...", Color.Black);

                    string[] toRemoveForMusics = { "Music/" };
                    WebClient musicsWebClient = downloadAndExtract(versionResponse.musicsLink, toRemoveForMusics);
                    musicsWebClient.DownloadFileCompleted += (object sender2, AsyncCompletedEventArgs e2) =>
                    {
                        if (CB_withTextures.Checked && versionResponse.texturesLink != "")
                        {
                            string[] toRemoveForTextures = { "mods/" };
                            WebClient textures = downloadAndExtract(versionResponse.texturesLink, toRemoveForTextures);
                            changeState("Téléchargement des textures en cours...", Color.Black);
                        }
                        else
                        {
                            changeState("Téléchargement terminé", Color.Green);
                            B_playGTA.Enabled = true;
                            this.B_desactivate.Enabled = true;
                            this.B_desactivate.Text = "Désactiver le mod";
                        }
                    };
                };
            }
            else
            {
                changeState("Problème lors du téléchargement", Color.Red);
                B_playGTA.Enabled = true;
            }
        }

        private WebClient downloadAndExtract (string link, string[] filesToRemove)
        {
            WebClient wc = new WebClient();
            
            string tempZipPath = gtaInstallationPath + "temp.zip";

            wc.DownloadProgressChanged += (object senderb, DownloadProgressChangedEventArgs e) =>
            {
                PB_modDownload.Value = e.ProgressPercentage;
            };
            wc.DownloadFileCompleted += (object senderb, AsyncCompletedEventArgs e) =>
            {
                foreach (string fileName in filesToRemove)
                {
                    string currentFileBackupLocation = gtaInstallationPath + backupFolderName + fileName;
                    string currentFileLocation = gtaInstallationPath + fileName;

                    try
                    {
                        if (Directory.Exists(currentFileLocation))
                        {
                            System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(currentFileLocation);
                            foreach (System.IO.FileInfo file in downloadedMessageInfo.GetFiles()) file.Delete();
                            foreach (System.IO.DirectoryInfo subDirectory in downloadedMessageInfo.GetDirectories()) subDirectory.Delete(true);
                            Directory.Delete(currentFileLocation);
                        }
                        
                        if (File.Exists(currentFileLocation))
                            File.Delete(currentFileLocation);
                    }
                    catch (IOException exception)
                    {
                        MessageBox.Show("Une erreur est surevenue pendant la suppression : " + exception.Message);
                    }
                }

                try
                {
                    ZipFile.ExtractToDirectory(tempZipPath, gtaInstallationPath);
                    File.Delete(tempZipPath);
                    checkModVersion();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Une erreur est survenue. Merci de contacter un membre de l'équipe : "+ exception.Message);
                }

                PB_modDownload.Value = 0;
            };

            wc.DownloadFileAsync(new System.Uri(link), tempZipPath);
            return wc;
        }

        private void B_playGTA_Click(object sender, EventArgs e)
        {
            if (checkInstallationPath())
            {
                System.Diagnostics.Process.Start(gtaInstallationPath + checkingFileName);
            }
        }

        private void B_instructions_Click(object sender, EventArgs e)
        {
            string text = "---------GTA Démago---------\nGTA démago, création de mod GTA V de façon participative\nhttp://nesblog.com/gta-demago/\n\n---------Installation---------\nIl n'y a qu'à lancer GTA V et utiliser les commandes en jeu pour ouvrir le menu GTA Démago.\nSi cela ne fonctionne pas, n'hésitez pas à nous contacter sur le forum : http://gtavdemago.forumactif.org/\n\n---------Commandes---------\nOuvrir le menu GTA Démago 	: F5 / Appuyer 2 fois sur la roue des armes\nSe déplacer dans les menus 	: Touches directionnelles / Croix directionnelle\nValider : Validation téléphone / Touche Num 5 du pad\nAnnuler : Annulation téléphone / Touche Num 0 du pad\n\n\nVersion 1.1 - 19 Avril 2016 - (Joyeux Anniversaire RealMyop !)\n\n - Vous avez peur des mecs à poil ? Alors ce mod n'est pas pour vous... :)\n - L'équipe de développeurs tient à informer que les organes génitaux de petite taille visibles dans le jeu grâce au mod n'ont malheureusement pas étés choisis en fonction de ceux des membres de l'équipe";
            MessageBox.Show(text);
        }
    }
}
