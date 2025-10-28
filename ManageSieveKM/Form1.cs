using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ManageSieveKM
{
    public partial class Form1 : Form
    {
        private RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64); //here you specify where exactly you want your entry
        private RegistryKey reg;
        private SieveConnect sieve;
        private string encryptionKey = Utils.GetEncryptionKey();
        private List<SieveScript> listS;
        private int lastRule = 0;

        public Form1(bool flushConfig = false)
        {
            InitializeComponent();
            reg = currentUser.OpenSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, true);
            if (reg == null)
            {
                reg = currentUser.CreateSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            }
            else
            {
                if (flushConfig)
                {
                    reg.Close();
                    currentUser.DeleteSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                    reg = currentUser.CreateSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                }
            }
            //host
            if (reg.GetValue("host") == null)
            {
                reg.SetValue("host", "");
            }
            else
            {
                tbHost.Text = reg.GetValue("host").ToString();
            }
            //port
            if (reg.GetValue("port") == null)
            {
                reg.SetValue("port", "4190");
            }
            else
            {
                tbPort.Text = reg.GetValue("port").ToString();
            }
            //TLS
            if (reg.GetValue("tls") == null)
            {
                reg.SetValue("tls", true.ToString());
            }
            else
            {
                chbSSL.Checked = Convert.ToBoolean(reg.GetValue("tls"));
            }
            //Ignore Validate Certificate
            if (reg.GetValue("ignoreValidade") == null)
            {
                reg.SetValue("ignoreValidade", false.ToString());
            }
            else
            {
                chbIgnore.Checked = Convert.ToBoolean(reg.GetValue("ignoreValidade"));
            }
            //email
            if (reg.GetValue("email") == null)
            {
                reg.SetValue("email", "");
            }
            else
            {
                tbEmail.Text = reg.GetValue("email").ToString();
            }
            //password
            if (reg.GetValue("password") == null)
            {
                reg.SetValue("password", "");
            }
            else
            {
                tbPassword.Text = "changeme";
            }
            //showOnlyAutoresponder
            if (reg.GetValue("showOnlyAutoresponder") == null)
            {
                reg.SetValue("showOnlyAutoresponder", false.ToString());
            }
            else
            {
                chbAutoresponder.Checked = Convert.ToBoolean(reg.GetValue("showOnlyAutoresponder"));
            }
            //lastRule
            if (reg.GetValue("lastRule") == null)
            {
                reg.SetValue("lastRule", "");
            }
            else
            {
                if (int.TryParse(reg.GetValue("lastRule").ToString(), out this.lastRule) == false)
                {
                    this.lastRule = -1;
                }
            }
            //Show autoresponder only
            if (chbAutoresponder.Checked)
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
                        Autoresponder a = new Autoresponder(tbScript.Text, this.lastRule);
                        a.ShowDialog();
                        if (a.DialogResult == DialogResult.OK)
                        {
                            tbScript.Text = a.NewScript;
                            reg.SetValue("lastRule", a.LastRule);
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
            if (tbHost.Text == "" || tbPort.Text == "" || tbEmail.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Please fill all text boxes (host, port, email and password).", "Stop",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            int port;
            if (int.TryParse(tbPort.Text, out port))
            {
                if (port < 1 || port > 65535)
                {
                    MessageBox.Show("Please write correct port number.", "Stop",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please write correct port number.", "Stop",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            this.sieve = new SieveConnect(tbHost.Text, tbEmail.Text, 
                Utils.Decrypt(reg.GetValue("password").ToString(), this.encryptionKey), 
                port, chbSSL.Checked, chbIgnore.Checked, chbDebug.Checked);
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

        private void tbHost_Leave(object sender, EventArgs e)
        {
            reg.SetValue("host", tbHost.Text);
        }

        private void tbPort_Leave(object sender, EventArgs e)
        {
            reg.SetValue("port", tbPort.Text);
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            reg.SetValue("email", tbEmail.Text);
        }

        private void chbSSL_Leave(object sender, EventArgs e)
        {
            reg.SetValue("tls", chbSSL.Checked.ToString());
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text != "changeme")
            {
                reg.SetValue("password", Utils.Encrypt(tbPassword.Text, this.encryptionKey));
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
            }
        }

        private void lbScripts_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbScripts.SelectedIndex > -1)
            {
                tbScript.Text = listS[lbScripts.SelectedIndex].Script;
            }
        }

        private void btAutoresponder_Click(object sender, EventArgs e)
        {
            if (tbScript.Text.Length > 0)
            {
                Autoresponder a = new Autoresponder(tbScript.Text, this.lastRule);
                a.ShowDialog();
                if (a.DialogResult == DialogResult.OK)
                {
                    tbScript.Text = a.NewScript;
                    reg.SetValue("lastRule", a.LastRule);
                }
            }
        }

        private void Send()
        {
            if (this.Connect())
            {
                if (sieve.SendScript(this.listS[lbScripts.SelectedIndex].Name, tbScript.Text) == false)
                {
                    MessageBox.Show("Can't send script! Error: " + this.sieve.Errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void chbIgnore_Leave(object sender, EventArgs e)
        {
            reg.SetValue("ignoreValidade", chbIgnore.Checked.ToString());
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void chbAutoresponder_CheckedChanged(object sender, EventArgs e)
        {
            reg.SetValue("showOnlyAutoresponder", chbAutoresponder.Checked.ToString());
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (chbAutoresponder.Checked)
            {
                this.Close();
            }
        }
    }
}
