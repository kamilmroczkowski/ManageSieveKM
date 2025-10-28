namespace ManageSieveKM
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbHost = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.chbSSL = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbAutoresponder = new System.Windows.Forms.CheckBox();
            this.chbDebug = new System.Windows.Forms.CheckBox();
            this.chbIgnore = new System.Windows.Forms.CheckBox();
            this.btAbout = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btGetScripts = new System.Windows.Forms.Button();
            this.lbScripts = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btAutoresponder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbScript = new System.Windows.Forms.TextBox();
            this.chbUpdate = new System.Windows.Forms.CheckBox();
            this.tbUpdateServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericFontSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(75, 19);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(281, 20);
            this.tbHost.TabIndex = 0;
            this.tbHost.Leave += new System.EventHandler(this.tbHost_Leave);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(75, 45);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(52, 20);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "4190";
            this.tbPort.Leave += new System.EventHandler(this.tbPort_Leave);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(75, 71);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(281, 20);
            this.tbEmail.TabIndex = 2;
            this.tbEmail.Leave += new System.EventHandler(this.tbEmail_Leave);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(75, 97);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '●';
            this.tbPassword.Size = new System.Drawing.Size(281, 20);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
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
            this.chbSSL.Leave += new System.EventHandler(this.chbSSL_Leave);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericFontSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbUpdateServer);
            this.groupBox1.Controls.Add(this.chbUpdate);
            this.groupBox1.Controls.Add(this.chbAutoresponder);
            this.groupBox1.Controls.Add(this.chbDebug);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 183);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sieve server";
            // 
            // chbAutoresponder
            // 
            this.chbAutoresponder.AutoSize = true;
            this.chbAutoresponder.Location = new System.Drawing.Point(98, 127);
            this.chbAutoresponder.Name = "chbAutoresponder";
            this.chbAutoresponder.Size = new System.Drawing.Size(146, 17);
            this.chbAutoresponder.TabIndex = 11;
            this.chbAutoresponder.Text = "Show only autoresponder";
            this.chbAutoresponder.UseVisualStyleBackColor = true;
            this.chbAutoresponder.CheckedChanged += new System.EventHandler(this.chbAutoresponder_CheckedChanged);
            // 
            // chbDebug
            // 
            this.chbDebug.AutoSize = true;
            this.chbDebug.Location = new System.Drawing.Point(6, 127);
            this.chbDebug.Name = "chbDebug";
            this.chbDebug.Size = new System.Drawing.Size(86, 17);
            this.chbDebug.TabIndex = 10;
            this.chbDebug.Text = "Debug to file";
            this.chbDebug.UseVisualStyleBackColor = true;
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
            this.chbIgnore.Leave += new System.EventHandler(this.chbIgnore_Leave);
            // 
            // btAbout
            // 
            this.btAbout.Location = new System.Drawing.Point(161, 300);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(75, 23);
            this.btAbout.TabIndex = 2;
            this.btAbout.Text = "About";
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btGetScripts);
            this.groupBox2.Controls.Add(this.lbScripts);
            this.groupBox2.Location = new System.Drawing.Point(386, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 183);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List scripts";
            // 
            // btGetScripts
            // 
            this.btGetScripts.Location = new System.Drawing.Point(6, 137);
            this.btGetScripts.Name = "btGetScripts";
            this.btGetScripts.Size = new System.Drawing.Size(219, 33);
            this.btGetScripts.TabIndex = 11;
            this.btGetScripts.Text = "Get scripts";
            this.btGetScripts.UseVisualStyleBackColor = true;
            this.btGetScripts.Click += new System.EventHandler(this.btGetScripts_Click);
            // 
            // lbScripts
            // 
            this.lbScripts.FormattingEnabled = true;
            this.lbScripts.Location = new System.Drawing.Point(6, 19);
            this.lbScripts.Name = "lbScripts";
            this.lbScripts.ScrollAlwaysVisible = true;
            this.lbScripts.Size = new System.Drawing.Size(219, 108);
            this.lbScripts.TabIndex = 0;
            this.lbScripts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbScripts_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btAutoresponder);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.tbScript);
            this.groupBox3.Controls.Add(this.btAbout);
            this.groupBox3.Location = new System.Drawing.Point(12, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(605, 329);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Script";
            // 
            // btAutoresponder
            // 
            this.btAutoresponder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btAutoresponder.Location = new System.Drawing.Point(450, 300);
            this.btAutoresponder.Name = "btAutoresponder";
            this.btAutoresponder.Size = new System.Drawing.Size(149, 23);
            this.btAutoresponder.TabIndex = 2;
            this.btAutoresponder.Text = "Autoresponder";
            this.btAutoresponder.UseVisualStyleBackColor = true;
            this.btAutoresponder.Click += new System.EventHandler(this.btAutoresponder_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(6, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbScript
            // 
            this.tbScript.Location = new System.Drawing.Point(6, 19);
            this.tbScript.Multiline = true;
            this.tbScript.Name = "tbScript";
            this.tbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScript.Size = new System.Drawing.Size(593, 275);
            this.tbScript.TabIndex = 0;
            // 
            // chbUpdate
            // 
            this.chbUpdate.AutoSize = true;
            this.chbUpdate.Location = new System.Drawing.Point(6, 152);
            this.chbUpdate.Name = "chbUpdate";
            this.chbUpdate.Size = new System.Drawing.Size(96, 17);
            this.chbUpdate.TabIndex = 12;
            this.chbUpdate.Text = "Check update:";
            this.chbUpdate.UseVisualStyleBackColor = true;
            // 
            // tbUpdateServer
            // 
            this.tbUpdateServer.Location = new System.Drawing.Point(108, 150);
            this.tbUpdateServer.Name = "tbUpdateServer";
            this.tbUpdateServer.Size = new System.Drawing.Size(248, 20);
            this.tbUpdateServer.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Font size:";
            // 
            // numericFontSize
            // 
            this.numericFontSize.Location = new System.Drawing.Point(308, 126);
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
            8,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 542);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageSieveKM";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.CheckBox chbSSL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbScripts;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbScript;
        private System.Windows.Forms.Button btGetScripts;
        private System.Windows.Forms.Button btAbout;
        private System.Windows.Forms.Button btAutoresponder;
        private System.Windows.Forms.CheckBox chbIgnore;
        private System.Windows.Forms.CheckBox chbDebug;
        private System.Windows.Forms.CheckBox chbAutoresponder;
        private System.Windows.Forms.TextBox tbUpdateServer;
        private System.Windows.Forms.CheckBox chbUpdate;
        private System.Windows.Forms.NumericUpDown numericFontSize;
        private System.Windows.Forms.Label label5;
    }
}

