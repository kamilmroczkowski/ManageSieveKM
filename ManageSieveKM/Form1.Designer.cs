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
            this.numericFontSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chbUpdate = new System.Windows.Forms.CheckBox();
            this.btAbout = new System.Windows.Forms.Button();
            this.chbAutoresponder = new System.Windows.Forms.CheckBox();
            this.chbDebug = new System.Windows.Forms.CheckBox();
            this.chbIgnore = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btGetScripts = new System.Windows.Forms.Button();
            this.lbScripts = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btAutoresponder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbScript = new System.Windows.Forms.TextBox();
            this.chbFixBuffor = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(100, 23);
            this.tbHost.Margin = new System.Windows.Forms.Padding(4);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(373, 23);
            this.tbHost.TabIndex = 0;
            this.tbHost.Leave += new System.EventHandler(this.tbHost_Leave);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(100, 55);
            this.tbPort.Margin = new System.Windows.Forms.Padding(4);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(68, 23);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "4190";
            this.tbPort.Leave += new System.EventHandler(this.tbPort_Leave);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(100, 87);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(373, 23);
            this.tbEmail.TabIndex = 2;
            this.tbEmail.Leave += new System.EventHandler(this.tbEmail_Leave);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(100, 119);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '●';
            this.tbPassword.Size = new System.Drawing.Size(373, 23);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
            // 
            // chbSSL
            // 
            this.chbSSL.AutoSize = true;
            this.chbSSL.Checked = true;
            this.chbSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSSL.Location = new System.Drawing.Point(177, 58);
            this.chbSSL.Margin = new System.Windows.Forms.Padding(4);
            this.chbSSL.Name = "chbSSL";
            this.chbSSL.Size = new System.Drawing.Size(83, 21);
            this.chbSSL.TabIndex = 4;
            this.chbSSL.Text = "SSL/TLS";
            this.chbSSL.UseVisualStyleBackColor = true;
            this.chbSSL.Leave += new System.EventHandler(this.chbSSL_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Host:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbFixBuffor);
            this.groupBox1.Controls.Add(this.numericFontSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chbUpdate);
            this.groupBox1.Controls.Add(this.btAbout);
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
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(491, 225);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sieve server";
            // 
            // numericFontSize
            // 
            this.numericFontSize.Location = new System.Drawing.Point(411, 155);
            this.numericFontSize.Margin = new System.Windows.Forms.Padding(4);
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
            this.numericFontSize.Size = new System.Drawing.Size(64, 23);
            this.numericFontSize.TabIndex = 15;
            this.numericFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericFontSize.Leave += new System.EventHandler(this.numericFontSize_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Font size:";
            // 
            // chbUpdate
            // 
            this.chbUpdate.AutoSize = true;
            this.chbUpdate.Checked = true;
            this.chbUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUpdate.Location = new System.Drawing.Point(8, 187);
            this.chbUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.chbUpdate.Name = "chbUpdate";
            this.chbUpdate.Size = new System.Drawing.Size(114, 21);
            this.chbUpdate.TabIndex = 12;
            this.chbUpdate.Text = "Check update";
            this.chbUpdate.UseVisualStyleBackColor = true;
            this.chbUpdate.CheckedChanged += new System.EventHandler(this.chbUpdate_CheckedChanged);
            // 
            // btAbout
            // 
            this.btAbout.Location = new System.Drawing.Point(383, 190);
            this.btAbout.Margin = new System.Windows.Forms.Padding(4);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(100, 28);
            this.btAbout.TabIndex = 2;
            this.btAbout.Text = "About";
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // chbAutoresponder
            // 
            this.chbAutoresponder.AutoSize = true;
            this.chbAutoresponder.Location = new System.Drawing.Point(131, 156);
            this.chbAutoresponder.Margin = new System.Windows.Forms.Padding(4);
            this.chbAutoresponder.Name = "chbAutoresponder";
            this.chbAutoresponder.Size = new System.Drawing.Size(188, 21);
            this.chbAutoresponder.TabIndex = 11;
            this.chbAutoresponder.Text = "Show only autoresponder";
            this.chbAutoresponder.UseVisualStyleBackColor = true;
            this.chbAutoresponder.CheckedChanged += new System.EventHandler(this.chbAutoresponder_CheckedChanged);
            // 
            // chbDebug
            // 
            this.chbDebug.AutoSize = true;
            this.chbDebug.Location = new System.Drawing.Point(8, 156);
            this.chbDebug.Margin = new System.Windows.Forms.Padding(4);
            this.chbDebug.Name = "chbDebug";
            this.chbDebug.Size = new System.Drawing.Size(107, 21);
            this.chbDebug.TabIndex = 10;
            this.chbDebug.Text = "Debug to file";
            this.chbDebug.UseVisualStyleBackColor = true;
            this.chbDebug.CheckedChanged += new System.EventHandler(this.chbDebug_CheckedChanged);
            // 
            // chbIgnore
            // 
            this.chbIgnore.AutoSize = true;
            this.chbIgnore.Location = new System.Drawing.Point(280, 58);
            this.chbIgnore.Margin = new System.Windows.Forms.Padding(4);
            this.chbIgnore.Name = "chbIgnore";
            this.chbIgnore.Size = new System.Drawing.Size(185, 21);
            this.chbIgnore.TabIndex = 9;
            this.chbIgnore.Text = "Ignore validate certificate";
            this.chbIgnore.UseVisualStyleBackColor = true;
            this.chbIgnore.Leave += new System.EventHandler(this.chbIgnore_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btGetScripts);
            this.groupBox2.Controls.Add(this.lbScripts);
            this.groupBox2.Location = new System.Drawing.Point(515, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(308, 225);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List scripts";
            // 
            // btGetScripts
            // 
            this.btGetScripts.Location = new System.Drawing.Point(8, 169);
            this.btGetScripts.Margin = new System.Windows.Forms.Padding(4);
            this.btGetScripts.Name = "btGetScripts";
            this.btGetScripts.Size = new System.Drawing.Size(292, 41);
            this.btGetScripts.TabIndex = 11;
            this.btGetScripts.Text = "Get scripts";
            this.btGetScripts.UseVisualStyleBackColor = true;
            this.btGetScripts.Click += new System.EventHandler(this.btGetScripts_Click);
            // 
            // lbScripts
            // 
            this.lbScripts.FormattingEnabled = true;
            this.lbScripts.ItemHeight = 16;
            this.lbScripts.Location = new System.Drawing.Point(8, 23);
            this.lbScripts.Margin = new System.Windows.Forms.Padding(4);
            this.lbScripts.Name = "lbScripts";
            this.lbScripts.ScrollAlwaysVisible = true;
            this.lbScripts.Size = new System.Drawing.Size(291, 132);
            this.lbScripts.TabIndex = 0;
            this.lbScripts.SelectedIndexChanged += new System.EventHandler(this.lbScripts_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btAutoresponder);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.tbScript);
            this.groupBox3.Location = new System.Drawing.Point(16, 247);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(807, 405);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Script";
            // 
            // btAutoresponder
            // 
            this.btAutoresponder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btAutoresponder.Location = new System.Drawing.Point(600, 369);
            this.btAutoresponder.Margin = new System.Windows.Forms.Padding(4);
            this.btAutoresponder.Name = "btAutoresponder";
            this.btAutoresponder.Size = new System.Drawing.Size(199, 28);
            this.btAutoresponder.TabIndex = 2;
            this.btAutoresponder.Text = "Autoresponder";
            this.btAutoresponder.UseVisualStyleBackColor = true;
            this.btAutoresponder.Click += new System.EventHandler(this.btAutoresponder_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(8, 369);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbScript
            // 
            this.tbScript.Location = new System.Drawing.Point(8, 23);
            this.tbScript.Margin = new System.Windows.Forms.Padding(4);
            this.tbScript.Multiline = true;
            this.tbScript.Name = "tbScript";
            this.tbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScript.Size = new System.Drawing.Size(789, 338);
            this.tbScript.TabIndex = 0;
            // 
            // chbFixBuffor
            // 
            this.chbFixBuffor.AutoSize = true;
            this.chbFixBuffor.Checked = true;
            this.chbFixBuffor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbFixBuffor.Location = new System.Drawing.Point(131, 187);
            this.chbFixBuffor.Name = "chbFixBuffor";
            this.chbFixBuffor.Size = new System.Drawing.Size(85, 21);
            this.chbFixBuffor.TabIndex = 16;
            this.chbFixBuffor.Text = "Fix buffor";
            this.chbFixBuffor.UseVisualStyleBackColor = true;
            this.chbFixBuffor.CheckedChanged += new System.EventHandler(this.chbFixBuffor_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 667);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ManageSieveKM";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.CheckBox chbUpdate;
        private System.Windows.Forms.NumericUpDown numericFontSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbFixBuffor;
    }
}

