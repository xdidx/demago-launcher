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
            this.pathGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.L_modVersion = new System.Windows.Forms.Label();
            this.B_desactivate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pathGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gtaLauncherFileDialog
            // 
            this.gtaLauncherFileDialog.FileName = "GTA5.exe";
            this.gtaLauncherFileDialog.Filter = "GTA5.exe|GTA5.exe";
            // 
            // L_gtaInstallationPath
            // 
            this.L_gtaInstallationPath.AutoSize = true;
            this.L_gtaInstallationPath.Location = new System.Drawing.Point(6, 25);
            this.L_gtaInstallationPath.Name = "L_gtaInstallationPath";
            this.L_gtaInstallationPath.Size = new System.Drawing.Size(117, 13);
            this.L_gtaInstallationPath.TabIndex = 0;
            this.L_gtaInstallationPath.Text = "Chargement en cours...";
            // 
            // B_chooseGtaFile
            // 
            this.B_chooseGtaFile.Location = new System.Drawing.Point(57, 50);
            this.B_chooseGtaFile.Name = "B_chooseGtaFile";
            this.B_chooseGtaFile.Size = new System.Drawing.Size(220, 29);
            this.B_chooseGtaFile.TabIndex = 1;
            this.B_chooseGtaFile.Text = "Chargement...";
            this.B_chooseGtaFile.UseVisualStyleBackColor = true;
            this.B_chooseGtaFile.Click += new System.EventHandler(this.B_chooseGtaFile_Click);
            // 
            // pathGroupBox
            // 
            this.pathGroupBox.Controls.Add(this.B_chooseGtaFile);
            this.pathGroupBox.Controls.Add(this.L_gtaInstallationPath);
            this.pathGroupBox.Location = new System.Drawing.Point(12, 40);
            this.pathGroupBox.Name = "pathGroupBox";
            this.pathGroupBox.Size = new System.Drawing.Size(334, 85);
            this.pathGroupBox.TabIndex = 2;
            this.pathGroupBox.TabStop = false;
            this.pathGroupBox.Text = "Chemin d\'installation de GTA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version du mod";
            // 
            // L_modVersion
            // 
            this.L_modVersion.AutoSize = true;
            this.L_modVersion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_modVersion.Location = new System.Drawing.Point(130, 9);
            this.L_modVersion.Name = "L_modVersion";
            this.L_modVersion.Size = new System.Drawing.Size(21, 19);
            this.L_modVersion.TabIndex = 4;
            this.L_modVersion.Text = "...";
            // 
            // B_desactivate
            // 
            this.B_desactivate.Enabled = false;
            this.B_desactivate.Location = new System.Drawing.Point(210, 4);
            this.B_desactivate.Name = "B_desactivate";
            this.B_desactivate.Size = new System.Drawing.Size(136, 30);
            this.B_desactivate.TabIndex = 2;
            this.B_desactivate.Text = "Mod non installé";
            this.B_desactivate.UseVisualStyleBackColor = true;
            this.B_desactivate.Click += new System.EventHandler(this.B_desactivate_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(334, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "Jouer à GTA V";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 239);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.B_desactivate);
            this.Controls.Add(this.pathGroupBox);
            this.Controls.Add(this.L_modVersion);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "GTA Démago Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pathGroupBox.ResumeLayout(false);
            this.pathGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog gtaLauncherFileDialog;
        private System.Windows.Forms.Label L_gtaInstallationPath;
        private System.Windows.Forms.Button B_chooseGtaFile;
        private System.Windows.Forms.Label L_modVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox pathGroupBox;
        private System.Windows.Forms.Button B_desactivate;
        private System.Windows.Forms.Button button1;
    }
}

