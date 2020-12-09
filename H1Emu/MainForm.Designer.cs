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
            this.startDownloadBtn = new System.Windows.Forms.Button();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.argsText = new System.Windows.Forms.TextBox();
            this.consoleLogs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startDownloadBtn
            // 
            this.startDownloadBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.startDownloadBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.startDownloadBtn.Location = new System.Drawing.Point(259, 251);
            this.startDownloadBtn.Name = "startDownloadBtn";
            this.startDownloadBtn.Size = new System.Drawing.Size(284, 23);
            this.startDownloadBtn.TabIndex = 0;
            this.startDownloadBtn.Text = "Start Download";
            this.startDownloadBtn.UseVisualStyleBackColor = false;
            this.startDownloadBtn.Click += new System.EventHandler(this.startDownloadBtn_Click);
            // 
            // usernameText
            // 
            this.usernameText.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.usernameText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameText.Location = new System.Drawing.Point(11, 40);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(231, 20);
            this.usernameText.TabIndex = 1;
            // 
            // passwordText
            // 
            this.passwordText.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.passwordText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordText.Location = new System.Drawing.Point(11, 88);
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '*';
            this.passwordText.Size = new System.Drawing.Size(231, 20);
            this.passwordText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Steam Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Steam Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Arguments";
            // 
            // argsText
            // 
            this.argsText.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.argsText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.argsText.Location = new System.Drawing.Point(289, 40);
            this.argsText.Multiline = true;
            this.argsText.Name = "argsText";
            this.argsText.Size = new System.Drawing.Size(423, 68);
            this.argsText.TabIndex = 7;
            this.argsText.Text = "-app 295110 -depot 295111 -manifest 1930886153446950288";
            // 
            // consoleLogs
            // 
            this.consoleLogs.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.consoleLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoleLogs.Location = new System.Drawing.Point(11, 147);
            this.consoleLogs.Multiline = true;
            this.consoleLogs.Name = "consoleLogs";
            this.consoleLogs.Size = new System.Drawing.Size(428, 87);
            this.consoleLogs.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Console";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 286);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.consoleLogs);
            this.Controls.Add(this.argsText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.startDownloadBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "H1DepotDownloader by H1emu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startDownloadBtn;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox argsText;
        private System.Windows.Forms.TextBox consoleLogs;
        private System.Windows.Forms.Label label4;
    }
}

