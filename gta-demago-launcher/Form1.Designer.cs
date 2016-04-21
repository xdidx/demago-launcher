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
            this.gtaLauncherFileDialog.Filter = "GTAVLauncher.exe|GTAVLauncher.exe";
            // 
            // L_gtaInstallationPath
            // 
            this.L_gtaInstallationPath.AutoSize = true;
            this.L_gtaInstallationPath.Location = new System.Drawing.Point(14, 78);
            this.L_gtaInstallationPath.Name = "L_gtaInstallationPath";
            this.L_gtaInstallationPath.Size = new System.Drawing.Size(117, 13);
            this.L_gtaInstallationPath.TabIndex = 0;
            this.L_gtaInstallationPath.Text = "Chargement en cours...";
            // 
            // B_chooseGtaFile
            // 
            this.B_chooseGtaFile.Location = new System.Drawing.Point(12, 99);
            this.B_chooseGtaFile.Name = "B_chooseGtaFile";
            this.B_chooseGtaFile.Size = new System.Drawing.Size(259, 29);
            this.B_chooseGtaFile.TabIndex = 1;
            this.B_chooseGtaFile.Text = "Modifier le répertoire d\'installation de GTA V";
            this.B_chooseGtaFile.UseVisualStyleBackColor = true;
            this.B_chooseGtaFile.Click += new System.EventHandler(this.B_chooseGtaFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version du mod";
            // 
            // L_modVersion
            // 
            this.L_modVersion.AutoSize = true;
            this.L_modVersion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_modVersion.Location = new System.Drawing.Point(137, 32);
            this.L_modVersion.Name = "L_modVersion";
            this.L_modVersion.Size = new System.Drawing.Size(21, 19);
            this.L_modVersion.TabIndex = 4;
            this.L_modVersion.Text = "...";
            // 
            // B_playGTA
            // 
            this.B_playGTA.BackColor = System.Drawing.Color.Black;
            this.B_playGTA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.B_playGTA.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_playGTA.ForeColor = System.Drawing.Color.Snow;
            this.B_playGTA.Location = new System.Drawing.Point(12, 192);
            this.B_playGTA.Name = "B_playGTA";
            this.B_playGTA.Size = new System.Drawing.Size(534, 37);
            this.B_playGTA.TabIndex = 5;
            this.B_playGTA.Text = "Jouer à GTA V";
            this.B_playGTA.UseVisualStyleBackColor = false;
            this.B_playGTA.Click += new System.EventHandler(this.B_playGTA_Click);
            // 
            // B_update_mod
            // 
            this.B_update_mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.B_update_mod.Location = new System.Drawing.Point(277, 99);
            this.B_update_mod.Name = "B_update_mod";
            this.B_update_mod.Size = new System.Drawing.Size(269, 29);
            this.B_update_mod.TabIndex = 6;
            this.B_update_mod.Text = "Télécharger le mod";
            this.B_update_mod.UseVisualStyleBackColor = true;
            this.B_update_mod.Click += new System.EventHandler(this.B_update_mod_Click);
            // 
            // L_state
            // 
            this.L_state.AutoSize = true;
            this.L_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_state.Location = new System.Drawing.Point(13, 3);
            this.L_state.Name = "L_state";
            this.L_state.Size = new System.Drawing.Size(249, 24);
            this.L_state.TabIndex = 7;
            this.L_state.Text = "Démarrage du programme...";
            // 
            // CB_withTextures
            // 
            this.CB_withTextures.AutoSize = true;
            this.CB_withTextures.Location = new System.Drawing.Point(277, 134);
            this.CB_withTextures.Name = "CB_withTextures";
            this.CB_withTextures.Size = new System.Drawing.Size(231, 17);
            this.CB_withTextures.TabIndex = 9;
            this.CB_withTextures.Text = "Inclure les textures personnalisées (3.23Go)";
            this.CB_withTextures.UseVisualStyleBackColor = true;
            // 
            // PB_modDownload
            // 
            this.PB_modDownload.Location = new System.Drawing.Point(12, 169);
            this.PB_modDownload.Name = "PB_modDownload";
            this.PB_modDownload.Size = new System.Drawing.Size(259, 17);
            this.PB_modDownload.TabIndex = 10;
            // 
            // B_desactivate
            // 
            this.B_desactivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.B_desactivate.Location = new System.Drawing.Point(12, 134);
            this.B_desactivate.Name = "B_desactivate";
            this.B_desactivate.Size = new System.Drawing.Size(259, 29);
            this.B_desactivate.TabIndex = 11;
            this.B_desactivate.Text = "Désactiver le mod";
            this.B_desactivate.UseVisualStyleBackColor = true;
            this.B_desactivate.Click += new System.EventHandler(this.B_desactivate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::gta_demago_launcher.Properties.Resources.gta_demago;
            this.pictureBox1.Location = new System.Drawing.Point(445, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // L_ErrorDescription
            // 
            this.L_ErrorDescription.AutoSize = true;
            this.L_ErrorDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.L_ErrorDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.L_ErrorDescription.ForeColor = System.Drawing.Color.Red;
            this.L_ErrorDescription.Location = new System.Drawing.Point(19, 60);
            this.L_ErrorDescription.Name = "L_ErrorDescription";
            this.L_ErrorDescription.Size = new System.Drawing.Size(0, 18);
            this.L_ErrorDescription.TabIndex = 13;
            // 
            // B_instructions
            // 
            this.B_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.B_instructions.Location = new System.Drawing.Point(277, 157);
            this.B_instructions.Name = "B_instructions";
            this.B_instructions.Size = new System.Drawing.Size(269, 29);
            this.B_instructions.TabIndex = 14;
            this.B_instructions.Text = "Voir les instructions";
            this.B_instructions.UseVisualStyleBackColor = true;
            this.B_instructions.Click += new System.EventHandler(this.B_instructions_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(558, 241);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(574, 280);
            this.MinimumSize = new System.Drawing.Size(574, 280);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "GTA Démago Launcher";
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

