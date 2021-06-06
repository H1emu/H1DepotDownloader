namespace H1DepotDownloader
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.usernameText = new MaterialSkin.Controls.MaterialTextBox();
            this.passwordText = new MaterialSkin.Controls.MaterialTextBox();
            this.argsText = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.startDownloadBtn = new MaterialSkin.Controls.MaterialButton();
            this.outputLabel = new System.Windows.Forms.Label();
            this.directory = new MaterialSkin.Controls.MaterialTextBox();
            this.consoleLogs = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.jan2015 = new MaterialSkin.Controls.MaterialRadioButton();
            this.dec2016 = new MaterialSkin.Controls.MaterialRadioButton();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameText.Depth = 0;
            this.usernameText.Font = new System.Drawing.Font("Roboto", 12F);
            this.usernameText.Hint = "Steam Username";
            this.usernameText.Location = new System.Drawing.Point(22, 91);
            this.usernameText.MaxLength = 50;
            this.usernameText.MouseState = MaterialSkin.MouseState.OUT;
            this.usernameText.Multiline = false;
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(343, 50);
            this.usernameText.TabIndex = 10;
            this.usernameText.Text = "";
            // 
            // passwordText
            // 
            this.passwordText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordText.Depth = 0;
            this.passwordText.Font = new System.Drawing.Font("Roboto", 12F);
            this.passwordText.Hint = "Steam Password";
            this.passwordText.Location = new System.Drawing.Point(22, 167);
            this.passwordText.MaxLength = 50;
            this.passwordText.MouseState = MaterialSkin.MouseState.OUT;
            this.passwordText.Multiline = false;
            this.passwordText.Name = "passwordText";
            this.passwordText.Password = true;
            this.passwordText.Size = new System.Drawing.Size(343, 50);
            this.passwordText.TabIndex = 11;
            this.passwordText.Text = "";
            // 
            // argsText
            // 
            this.argsText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.argsText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.argsText.Depth = 0;
            this.argsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.argsText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.argsText.Hint = "Arguments";
            this.argsText.Location = new System.Drawing.Point(380, 91);
            this.argsText.MouseState = MaterialSkin.MouseState.HOVER;
            this.argsText.Name = "argsText";
            this.argsText.Size = new System.Drawing.Size(402, 126);
            this.argsText.TabIndex = 12;
            this.argsText.Text = "";
            // 
            // startDownloadBtn
            // 
            this.startDownloadBtn.AutoSize = false;
            this.startDownloadBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startDownloadBtn.Depth = 0;
            this.startDownloadBtn.DrawShadows = true;
            this.startDownloadBtn.HighEmphasis = true;
            this.startDownloadBtn.Icon = null;
            this.startDownloadBtn.Location = new System.Drawing.Point(380, 240);
            this.startDownloadBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.startDownloadBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.startDownloadBtn.Name = "startDownloadBtn";
            this.startDownloadBtn.Size = new System.Drawing.Size(402, 50);
            this.startDownloadBtn.TabIndex = 13;
            this.startDownloadBtn.Text = "Start Download";
            this.startDownloadBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.startDownloadBtn.UseAccentColor = false;
            this.startDownloadBtn.UseVisualStyleBackColor = true;
            this.startDownloadBtn.Click += new System.EventHandler(this.startDownloadBtn_Click_1);
            // 
            // outputLabel
            // 
            this.outputLabel.Location = new System.Drawing.Point(19, 308);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(175, 23);
            this.outputLabel.TabIndex = 14;
            this.outputLabel.Text = "Output";
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // directory
            // 
            this.directory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.directory.Depth = 0;
            this.directory.Enabled = false;
            this.directory.Font = new System.Drawing.Font("Roboto", 12F);
            this.directory.Hint = "Install Location";
            this.directory.Location = new System.Drawing.Point(22, 240);
            this.directory.MaxLength = 50;
            this.directory.MouseState = MaterialSkin.MouseState.OUT;
            this.directory.Multiline = false;
            this.directory.Name = "directory";
            this.directory.Size = new System.Drawing.Size(343, 50);
            this.directory.TabIndex = 15;
            this.directory.Text = "";
            // 
            // consoleLogs
            // 
            this.consoleLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoleLogs.Location = new System.Drawing.Point(22, 352);
            this.consoleLogs.Multiline = true;
            this.consoleLogs.Name = "consoleLogs";
            this.consoleLogs.ReadOnly = true;
            this.consoleLogs.Size = new System.Drawing.Size(760, 260);
            this.consoleLogs.TabIndex = 17;
            // 
            // jan2015
            // 
            this.jan2015.AutoSize = true;
            this.jan2015.Depth = 0;
            this.jan2015.Location = new System.Drawing.Point(476, 301);
            this.jan2015.Margin = new System.Windows.Forms.Padding(0);
            this.jan2015.MouseLocation = new System.Drawing.Point(-1, -1);
            this.jan2015.MouseState = MaterialSkin.MouseState.HOVER;
            this.jan2015.Name = "jan2015";
            this.jan2015.Ripple = true;
            this.jan2015.Size = new System.Drawing.Size(133, 37);
            this.jan2015.TabIndex = 18;
            this.jan2015.TabStop = true;
            this.jan2015.Text = "January 2015";
            this.jan2015.UseVisualStyleBackColor = true;
            this.jan2015.CheckedChanged += new System.EventHandler(this.jan2015_CheckedChanged);
            // 
            // dec2016
            // 
            this.dec2016.AutoSize = true;
            this.dec2016.Depth = 0;
            this.dec2016.Location = new System.Drawing.Point(636, 301);
            this.dec2016.Margin = new System.Windows.Forms.Padding(0);
            this.dec2016.MouseLocation = new System.Drawing.Point(-1, -1);
            this.dec2016.MouseState = MaterialSkin.MouseState.HOVER;
            this.dec2016.Name = "dec2016";
            this.dec2016.Ripple = true;
            this.dec2016.Size = new System.Drawing.Size(146, 37);
            this.dec2016.TabIndex = 19;
            this.dec2016.TabStop = true;
            this.dec2016.Text = "December 2016";
            this.dec2016.UseVisualStyleBackColor = true;
            this.dec2016.CheckedChanged += new System.EventHandler(this.dec2016_CheckedChanged);
            // 
            // versionLabel
            // 
            this.versionLabel.Location = new System.Drawing.Point(377, 308);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(100, 23);
            this.versionLabel.TabIndex = 20;
            this.versionLabel.Text = "Version:";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(804, 635);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.dec2016);
            this.Controls.Add(this.jan2015);
            this.Controls.Add(this.consoleLogs);
            this.Controls.Add(this.directory);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.startDownloadBtn);
            this.Controls.Add(this.argsText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H1Emu - DepotDownloader - ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox passwordText;
        private MaterialSkin.Controls.MaterialMultiLineTextBox argsText;
        private MaterialSkin.Controls.MaterialButton startDownloadBtn;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox consoleLogs;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        public MaterialSkin.Controls.MaterialTextBox directory;
        public MaterialSkin.Controls.MaterialTextBox usernameText;
        private MaterialSkin.Controls.MaterialRadioButton jan2015;
        private MaterialSkin.Controls.MaterialRadioButton dec2016;
        private System.Windows.Forms.Label versionLabel;
    }
}

