using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net;
using System.IO;

namespace ManageSieveKM
{
    public partial class Form1 : FormT
    {
        private SieveConnect sieve;
        private List<SieveScript> listS;

        public Form1(bool flushConfig = false)
        {
            InitializeComponent();
            new Loading(flushConfig).ShowDialog();
            //Show autoresponder only
            if (Configuration.ShowOnlyAutoresponder)
            {
                if (this.Connect())
                {
                    int i = 0;
                    lbScripts.Items.Clear();
                    this.listS = sieve.GetScripts();
                    if (this.sieve.Errors == "")
                    {
                        foreach (SieveScript s in listS)
                        {
                            lbScripts.Items.Add(s.Name + ((s.Active) ? " (ACTIVE)" : ""));
                            if (s.Active)
                            {
                                lbScripts.SelectedIndex = i;
                                tbScript.Text = s.Script;
                            }
                            i++;
                        }
                        this.sieve.Disconnect();
                        Autoresponder a = new Autoresponder(tbScript.Text);
                        a.ShowDialog();
                        if (a.DialogResult == DialogResult.OK)
                        {
                            tbScript.Text = a.NewScript;
                            this.Send();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't get scripts! Error: " + this.sieve.Errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("If you need flush config:\r\nEdit registry: HKEY_CURRENT_USER\\Software\\ManageSieveKM\r\nOr run with arguments: /flushConfig", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool Connect()
        {
            this.sieve = new SieveConnect();
            if (this.sieve.Connect())
            {
                return true;
            }
            else
            {
                MessageBox.Show("Can't log in! Error: " + this.sieve.Errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btGetScripts_Click(object sender, EventArgs e)
        {
            if (this.Connect())
            {
                lbScripts.Items.Clear();
                this.listS = sieve.GetScripts();
                if (this.sieve.Errors != "")
                {
                    MessageBox.Show("Can't get scripts! Error: " + this.sieve.Errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                foreach (SieveScript s in listS)
                {
                    lbScripts.Items.Add(s.Name + ((s.Active) ? " (ACTIVE)" : ""));
                }
                this.sieve.Disconnect();
                if (lbScripts.Items.Count > 0)
                {
                    lbScripts.SelectedIndex = 0;
                }
            }
        }

        private void btAutoresponder_Click(object sender, EventArgs e)
        {
            if (tbScript.Text.Length > 0)
            {
                Autoresponder a = new Autoresponder(tbScript.Text);
                a.ShowDialog();
                if (a.DialogResult == DialogResult.OK)
                {
                    tbScript.Text = a.NewScript;
                }
            }
        }

        private void Send()
        {
            if (this.Connect())
            {
                if (sieve.SendScript(this.listS[lbScripts.SelectedIndex].Name, tbScript.Text.Trim()) == false)
                {
                    string helper0 = "Try increasing the buffer by 2 and resend. Keep trying increase buffer until it works.";
                    if (this.sieve.Errors.IndexOf("Too many command arguments") == -1)
                    {
                        helper0 = "Try reducing the buffer by 2 and resend. Keep trying reducing until it works.";
                    }
                    MessageBox.Show("Can't send script! " + Environment.NewLine + Environment.NewLine + helper0 + Environment.NewLine + Environment.NewLine + "Error: " + this.sieve.Errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Send success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.sieve.Disconnect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbScript.Text.Trim().Length > 0)
            {
                this.Send();
            }
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Configuration.ShowOnlyAutoresponder)
            {
                this.Close();
            }
        }

        private void lbScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbScripts.SelectedIndex > -1)
            {
                tbScript.Text = listS[lbScripts.SelectedIndex].Script;
            }
        }

        private void btConfig_Click(object sender, EventArgs e)
        {
            new Config().ShowDialog();
        }
    }
}
