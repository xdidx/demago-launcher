namespace gta_demago_launcher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gtaLauncherFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.L_gtaInstallationPath = new System.Windows.Forms.Label();
            this.B_chooseGtaFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.L_modVersion = new System.Windows.Forms.Label();
            this.B_playGTA = new System.Windows.Forms.Button();
            this.B_update_mod = new System.Windows.Forms.Button();
            this.L_state = new System.Windows.Forms.Label();
            this.CB_withTextures = new System.Windows.Forms.CheckBox();
            this.PB_modDownload = new System.Windows.Forms.ProgressBar();
            this.B_desactivate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.L_ErrorDescription = new System.Windows.Forms.Label();
            this.B_instructions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gtaLauncherFileDialog
            // 
            this.gtaLauncherFileDialog.FileName = "GTAVLauncher.exe";
            resources.ApplyResources(this.gtaLauncherFileDialog, "gtaLauncherFileDialog");
            // 
            // L_gtaInstallationPath
            // 
            resources.ApplyResources(this.L_gtaInstallationPath, "L_gtaInstallationPath");
            this.L_gtaInstallationPath.Name = "L_gtaInstallationPath";
            // 
            // B_chooseGtaFile
            // 
            resources.ApplyResources(this.B_chooseGtaFile, "B_chooseGtaFile");
            this.B_chooseGtaFile.Name = "B_chooseGtaFile";
            this.B_chooseGtaFile.UseVisualStyleBackColor = true;
            this.B_chooseGtaFile.Click += new System.EventHandler(this.B_chooseGtaFile_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // L_modVersion
            // 
            resources.ApplyResources(this.L_modVersion, "L_modVersion");
            this.L_modVersion.Name = "L_modVersion";
            // 
            // B_playGTA
            // 
            this.B_playGTA.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.B_playGTA, "B_playGTA");
            this.B_playGTA.ForeColor = System.Drawing.Color.Snow;
            this.B_playGTA.Name = "B_playGTA";
            this.B_playGTA.UseVisualStyleBackColor = false;
            this.B_playGTA.Click += new System.EventHandler(this.B_playGTA_Click);
            // 
            // B_update_mod
            // 
            resources.ApplyResources(this.B_update_mod, "B_update_mod");
            this.B_update_mod.Name = "B_update_mod";
            this.B_update_mod.UseVisualStyleBackColor = true;
            this.B_update_mod.Click += new System.EventHandler(this.B_update_mod_Click);
            // 
            // L_state
            // 
            resources.ApplyResources(this.L_state, "L_state");
            this.L_state.Name = "L_state";
            // 
            // CB_withTextures
            // 
            resources.ApplyResources(this.CB_withTextures, "CB_withTextures");
            this.CB_withTextures.Name = "CB_withTextures";
            this.CB_withTextures.UseVisualStyleBackColor = true;
            // 
            // PB_modDownload
            // 
            resources.ApplyResources(this.PB_modDownload, "PB_modDownload");
            this.PB_modDownload.Name = "PB_modDownload";
            // 
            // B_desactivate
            // 
            resources.ApplyResources(this.B_desactivate, "B_desactivate");
            this.B_desactivate.Name = "B_desactivate";
            this.B_desactivate.UseVisualStyleBackColor = true;
            this.B_desactivate.Click += new System.EventHandler(this.B_desactivate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::gta_demago_launcher.Properties.Resources.gta_demago;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // L_ErrorDescription
            // 
            resources.ApplyResources(this.L_ErrorDescription, "L_ErrorDescription");
            this.L_ErrorDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.L_ErrorDescription.ForeColor = System.Drawing.Color.Red;
            this.L_ErrorDescription.Name = "L_ErrorDescription";
            // 
            // B_instructions
            // 
            resources.ApplyResources(this.B_instructions, "B_instructions");
            this.B_instructions.Name = "B_instructions";
            this.B_instructions.UseVisualStyleBackColor = true;
            this.B_instructions.Click += new System.EventHandler(this.B_instructions_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.B_instructions);
            this.Controls.Add(this.L_ErrorDescription);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.B_desactivate);
            this.Controls.Add(this.PB_modDownload);
            this.Controls.Add(this.CB_withTextures);
            this.Controls.Add(this.B_chooseGtaFile);
            this.Controls.Add(this.L_state);
            this.Controls.Add(this.L_gtaInstallationPath);
            this.Controls.Add(this.B_update_mod);
            this.Controls.Add(this.B_playGTA);
            this.Controls.Add(this.L_modVersion);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog gtaLauncherFileDialog;
        private System.Windows.Forms.Label L_gtaInstallationPath;
        private System.Windows.Forms.Button B_chooseGtaFile;
        private System.Windows.Forms.Label L_modVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_playGTA;
        private System.Windows.Forms.Button B_update_mod;
        private System.Windows.Forms.Label L_state;
        private System.Windows.Forms.CheckBox CB_withTextures;
        private System.Windows.Forms.ProgressBar PB_modDownload;
        private System.Windows.Forms.Button B_desactivate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label L_ErrorDescription;
        private System.Windows.Forms.Button B_instructions;
    }
}

