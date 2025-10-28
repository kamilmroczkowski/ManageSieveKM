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
        private RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
        private RegistryKey reg;
        private SieveConnect sieve;
        private string encryptionKey = Utils.GetEncryptionKey();
        private List<SieveScript> listS;
        private WebClient webclient = new WebClient();

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
            //fontSize
            if (reg.GetValue("fontSize") == null)
            {
                reg.SetValue("fontSize", "12");
            }
            else
            {
                decimal fs = 12;
                if (decimal.TryParse(reg.GetValue("fontSize").ToString(), out fs))
                {

                }
                numericFontSize.Value = fs;
            }
            //Debug
            if (reg.GetValue("debug") == null)
            {
                reg.SetValue("debug", false.ToString());
            }
            else
            {
                chbDebug.Checked = Convert.ToBoolean(reg.GetValue("debug"));
            }
            //fixBuffor
            if (reg.GetValue("fixBuffor") == null)
            {
                reg.SetValue("fixBuffor", false.ToString());
            }
            else
            {
                chbFixBuffor.Checked = Convert.ToBoolean(reg.GetValue("fixBuffor"));
            }
            //checkUpdate
            if (reg.GetValue("checkUpdate") == null)
            {
                reg.SetValue("checkUpdate", true.ToString());
            }
            else
            {
                chbUpdate.Checked = Convert.ToBoolean(reg.GetValue("checkUpdate"));
            }
            //update
            if (chbUpdate.Checked)
            {
                if (chbDebug.Checked)
                {
                    Utils.LogToFile("Check update...");
                }
                string file0;
                try
                {
                    string version = this.webclient.DownloadString("https://raw.githubusercontent.com/kamilmroczkowski/ManageSieveKM/refs/heads/main/Releases/version.txt").Trim();
                    if (chbDebug.Checked)
                    {
                        Utils.LogToFile("Check version in server: " + version);
                    }
                    if (System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() != version.Trim())
                    {
                        if (MessageBox.Show("Release new version - apply update program?", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (chbDebug.Checked)
                            {
                                Utils.LogToFile("Version is diffrent... update.");
                            }
                            file0 = "ManageSieveKM.exe";
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + file0))
                            {
                                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + file0 + ".bak"))
                                {
                                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + file0 + ".bak");
                                }
                                File.Move(AppDomain.CurrentDomain.BaseDirectory + file0, AppDomain.CurrentDomain.BaseDirectory + file0 + ".bak");
                            }
                            this.webclient.DownloadFile(new Uri("https://raw.githubusercontent.com/kamilmroczkowski/ManageSieveKM/refs/heads/main/Releases/" + version + "/" + file0), AppDomain.CurrentDomain.BaseDirectory + file0);
                            Process.Start(Application.ExecutablePath);
                            Process.GetCurrentProcess().Kill();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    if (ex.InnerException != null)
                    {
                        error += Environment.NewLine + ex.InnerException.Message;
                    }
                    MessageBox.Show("Update error: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (sieve.SendScript(this.listS[lbScripts.SelectedIndex].Name, tbScript.Text, chbFixBuffor.Checked) == false)
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

        private void numericFontSize_Leave(object sender, EventArgs e)
        {
            reg.SetValue("fontSize", numericFontSize.Value.ToString());
        }

        private void lbScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbScripts.SelectedIndex > -1)
            {
                tbScript.Text = listS[lbScripts.SelectedIndex].Script;
            }
        }

        private void chbDebug_CheckedChanged(object sender, EventArgs e)
        {
            reg.SetValue("debug", chbDebug.Checked.ToString());
        }

        private void chbUpdate_CheckedChanged(object sender, EventArgs e)
        {
            reg.SetValue("checkUpdate", chbUpdate.Checked.ToString());
        }

        private void chbFixBuffor_CheckedChanged(object sender, EventArgs e)
        {
            reg.SetValue("fixBuffor", chbFixBuffor.Checked.ToString());
        }
    }
}
