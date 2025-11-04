namespace ManageSieveKM
{
    partial class Config
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbIgnore = new System.Windows.Forms.CheckBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbSSL = new System.Windows.Forms.CheckBox();
            this.numericFontSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chbUpdate = new System.Windows.Forms.CheckBox();
            this.chbAutoresponder = new System.Windows.Forms.CheckBox();
            this.chbDebug = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbUpdateServer = new System.Windows.Forms.TextBox();
            this.chbSilentUpdate = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbIgnore);
            this.groupBox1.Controls.Add(this.tbHost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chbSSL);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 129);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sieve server";
            // 
            // chbIgnore
            // 
            this.chbIgnore.AutoSize = true;
            this.chbIgnore.Location = new System.Drawing.Point(210, 47);
            this.chbIgnore.Name = "chbIgnore";
            this.chbIgnore.Size = new System.Drawing.Size(145, 17);
            this.chbIgnore.TabIndex = 9;
            this.chbIgnore.Text = "Ignore validate certificate";
            this.chbIgnore.UseVisualStyleBackColor = true;
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(75, 19);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(281, 20);
            this.tbHost.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(75, 45);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(52, 20);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "4190";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(75, 71);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(281, 20);
            this.tbEmail.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(75, 97);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '●';
            this.tbPassword.Size = new System.Drawing.Size(281, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Host:";
            // 
            // chbSSL
            // 
            this.chbSSL.AutoSize = true;
            this.chbSSL.Checked = true;
            this.chbSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSSL.Location = new System.Drawing.Point(133, 47);
            this.chbSSL.Name = "chbSSL";
            this.chbSSL.Size = new System.Drawing.Size(71, 17);
            this.chbSSL.TabIndex = 4;
            this.chbSSL.Text = "SSL/TLS";
            this.chbSSL.UseVisualStyleBackColor = true;
            // 
            // numericFontSize
            // 
            this.numericFontSize.Location = new System.Drawing.Point(64, 65);
            this.numericFontSize.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericFontSize.Name = "numericFontSize";
            this.numericFontSize.Size = new System.Drawing.Size(48, 20);
            this.numericFontSize.TabIndex = 15;
            this.numericFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Font size:";
            // 
            // chbUpdate
            // 
            this.chbUpdate.AutoSize = true;
            this.chbUpdate.Checked = true;
            this.chbUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUpdate.Location = new System.Drawing.Point(5, 20);
            this.chbUpdate.Name = "chbUpdate";
            this.chbUpdate.Size = new System.Drawing.Size(93, 17);
            this.chbUpdate.TabIndex = 12;
            this.chbUpdate.Text = "Check update";
            this.chbUpdate.UseVisualStyleBackColor = true;
            // 
            // chbAutoresponder
            // 
            this.chbAutoresponder.AutoSize = true;
            this.chbAutoresponder.Location = new System.Drawing.Point(5, 43);
            this.chbAutoresponder.Name = "chbAutoresponder";
            this.chbAutoresponder.Size = new System.Drawing.Size(146, 17);
            this.chbAutoresponder.TabIndex = 11;
            this.chbAutoresponder.Text = "Show only autoresponder";
            this.chbAutoresponder.UseVisualStyleBackColor = true;
            // 
            // chbDebug
            // 
            this.chbDebug.AutoSize = true;
            this.chbDebug.Location = new System.Drawing.Point(5, 20);
            this.chbDebug.Name = "chbDebug";
            this.chbDebug.Size = new System.Drawing.Size(86, 17);
            this.chbDebug.TabIndex = 10;
            this.chbDebug.Text = "Debug to file";
            this.chbDebug.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.tbUpdateServer);
            this.groupBox2.Controls.Add(this.chbSilentUpdate);
            this.groupBox2.Controls.Add(this.chbUpdate);
            this.groupBox2.Location = new System.Drawing.Point(9, 145);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(369, 92);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Reset update server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbUpdateServer
            // 
            this.tbUpdateServer.Location = new System.Drawing.Point(4, 65);
            this.tbUpdateServer.Margin = new System.Windows.Forms.Padding(2);
            this.tbUpdateServer.Name = "tbUpdateServer";
            this.tbUpdateServer.Size = new System.Drawing.Size(361, 20);
            this.tbUpdateServer.TabIndex = 16;
            this.tbUpdateServer.Text = "https://raw.githubusercontent.com/kamilmroczkowski/ManageSieveKM/refs/heads/main/" +
    "Releases/";
            this.toolTip1.SetToolTip(this.tbUpdateServer, "https://1.2.3.4/update/\r\n\\\\1.2.3.4\\update\\");
            // 
            // chbSilentUpdate
            // 
            this.chbSilentUpdate.AutoSize = true;
            this.chbSilentUpdate.Location = new System.Drawing.Point(4, 43);
            this.chbSilentUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.chbSilentUpdate.Name = "chbSilentUpdate";
            this.chbSilentUpdate.Size = new System.Drawing.Size(88, 17);
            this.chbSilentUpdate.TabIndex = 14;
            this.chbSilentUpdate.Text = "Silent update";
            this.chbSilentUpdate.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericFontSize);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.chbDebug);
            this.groupBox3.Controls.Add(this.chbAutoresponder);
            this.groupBox3.Location = new System.Drawing.Point(9, 242);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(368, 93);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Others";
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btSave.Location = new System.Drawing.Point(136, 340);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(116, 23);
            this.btSave.TabIndex = 13;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Example servers";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 373);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Config";
            this.Text = "Config";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericFontSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbUpdate;
        private System.Windows.Forms.CheckBox chbAutoresponder;
        private System.Windows.Forms.CheckBox chbDebug;
        private System.Windows.Forms.CheckBox chbIgnore;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbSSL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbUpdateServer;
        private System.Windows.Forms.CheckBox chbSilentUpdate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}