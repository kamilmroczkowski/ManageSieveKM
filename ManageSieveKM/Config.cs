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
    public partial class Config : FormT
    {
        private RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
        private RegistryKey reg;

        public Config()
        {
            InitializeComponent();
            reg = currentUser.OpenSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, true);
            tbHost.Text = Configuration.Host;
            tbPort.Text = Configuration.Port.ToString();
            chbSSL.Checked = Configuration.Tls;
            chbIgnore.Checked = Configuration.IgnoreCert;
            tbEmail.Text = Configuration.Email;
            tbPassword.Text = "changeme";
            chbAutoresponder.Checked = Configuration.ShowOnlyAutoresponder;
            numericFontSize.Value = (decimal)Configuration.FontSize;
            chbDebug.Checked = Configuration.Debug;
            chbUpdate.Checked = Configuration.CheckUpdate;
            chbSilentUpdate.Checked = Configuration.SilentUpdate;
            tbUpdateServer.Text = Configuration.ServerUpdate;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbHost.Text == "" || tbPort.Text == "" || tbEmail.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Please fill all text boxes (host, port, email and password).", "Stop",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int port;
            if (int.TryParse(tbPort.Text, out port))
            {
                if (port < 1 || port > 65535)
                {
                    MessageBox.Show("Please write correct port number.", "Stop",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please write correct port number.", "Stop",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            reg.SetValue("host", tbHost.Text.Trim());
            reg.SetValue("port", port.ToString());
            reg.SetValue("tls", chbSSL.Checked.ToString());
            reg.SetValue("ignoreValidade", chbIgnore.Checked.ToString());
            reg.SetValue("email", tbEmail.Text);
            if (tbPassword.Text != "changeme")
            {
                reg.SetValue("password", Utils.Encrypt(tbPassword.Text, Configuration.EncryptionKey));
            }
            reg.SetValue("checkUpdate", chbUpdate.Checked.ToString());
            reg.SetValue("silentUpdate", chbSilentUpdate.Checked.ToString());
            if (tbUpdateServer.Text.Length > 0)
            {
                string aaa = tbUpdateServer.Text.Substring(tbUpdateServer.Text.Length - 1, 1);
                if (tbUpdateServer.Text.Substring(0, 4) == "http")
                {
                    if (tbUpdateServer.Text.Substring(tbUpdateServer.Text.Length - 1, 1) != "/")
                    {
                        tbUpdateServer.Text += "/";
                    }
                }
                else
                {
                    if (tbUpdateServer.Text.Substring(tbUpdateServer.Text.Length - 1, 1) != "\\")
                    {
                        tbUpdateServer.Text += "\\";
                    }
                }
            }
            reg.SetValue("updateServer", tbUpdateServer.Text.Trim());
            reg.SetValue("debug", chbDebug.Checked.ToString());
            reg.SetValue("showOnlyAutoresponder", chbAutoresponder.Checked.ToString());
            reg.SetValue("fontSize", numericFontSize.Value.ToString());
            Configuration.Host = tbHost.Text.Trim();
            Configuration.Port = port;
            Configuration.Tls = chbSSL.Checked;
            Configuration.IgnoreCert = chbIgnore.Checked;
            Configuration.Email = tbEmail.Text.Trim();
            if (tbPassword.Text != "changeme")
            {
                Configuration.Password = Utils.Encrypt(tbPassword.Text, Configuration.EncryptionKey);
            }
            Configuration.ShowOnlyAutoresponder = chbAutoresponder.Checked;
            Configuration.FontSize = (float)numericFontSize.Value;
            Configuration.Debug = chbDebug.Checked;
            Configuration.CheckUpdate = chbUpdate.Checked;
            Configuration.SilentUpdate = chbSilentUpdate.Checked;
            Configuration.ServerUpdate = tbUpdateServer.Text.Trim();
            MessageBox.Show("Save success.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbUpdateServer.Text = "https://raw.githubusercontent.com/kamilmroczkowski/ManageSieveKM/refs/heads/main/Releases/";
        }
    }
}
