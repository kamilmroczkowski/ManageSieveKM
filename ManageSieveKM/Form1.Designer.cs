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
            this.btAbout = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btGetScripts = new System.Windows.Forms.Button();
            this.lbScripts = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btConfig = new System.Windows.Forms.Button();
            this.btAutoresponder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbScript = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAbout
            // 
            this.btAbout.Location = new System.Drawing.Point(12, 90);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(177, 33);
            this.btAbout.TabIndex = 2;
            this.btAbout.Text = "About";
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbScripts);
            this.groupBox2.Location = new System.Drawing.Point(378, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 136);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List scripts";
            // 
            // btGetScripts
            // 
            this.btGetScripts.Location = new System.Drawing.Point(12, 12);
            this.btGetScripts.Name = "btGetScripts";
            this.btGetScripts.Size = new System.Drawing.Size(177, 33);
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
            this.lbScripts.Size = new System.Drawing.Size(177, 108);
            this.lbScripts.TabIndex = 0;
            this.lbScripts.SelectedIndexChanged += new System.EventHandler(this.lbScripts_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbScript);
            this.groupBox3.Location = new System.Drawing.Point(12, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(557, 304);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Script";
            // 
            // btConfig
            // 
            this.btConfig.Location = new System.Drawing.Point(12, 51);
            this.btConfig.Name = "btConfig";
            this.btConfig.Size = new System.Drawing.Size(177, 33);
            this.btConfig.TabIndex = 3;
            this.btConfig.Text = "Config";
            this.btConfig.UseVisualStyleBackColor = true;
            this.btConfig.Click += new System.EventHandler(this.btConfig_Click);
            // 
            // btAutoresponder
            // 
            this.btAutoresponder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btAutoresponder.Location = new System.Drawing.Point(195, 12);
            this.btAutoresponder.Name = "btAutoresponder";
            this.btAutoresponder.Size = new System.Drawing.Size(177, 33);
            this.btAutoresponder.TabIndex = 2;
            this.btAutoresponder.Text = "Autoresponder";
            this.btAutoresponder.UseVisualStyleBackColor = true;
            this.btAutoresponder.Click += new System.EventHandler(this.btAutoresponder_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(195, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 33);
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
            this.tbScript.ReadOnly = true;
            this.tbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScript.Size = new System.Drawing.Size(543, 275);
            this.tbScript.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 468);
            this.Controls.Add(this.btConfig);
            this.Controls.Add(this.btAbout);
            this.Controls.Add(this.btGetScripts);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btAutoresponder);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "ManageSieveKM";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbScripts;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbScript;
        private System.Windows.Forms.Button btGetScripts;
        private System.Windows.Forms.Button btAbout;
        private System.Windows.Forms.Button btAutoresponder;
        private System.Windows.Forms.Button btConfig;
    }
}

