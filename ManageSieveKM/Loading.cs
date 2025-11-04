using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ManageSieveKM
{
    public partial class Loading : FormT
    {
        private WebClient webclient = new WebClient();
        private bool flushConfig;

        public Loading(bool flushConfig)
        {
            InitializeComponent();
            this.flushConfig = flushConfig;
        }

        private void debugLog(string msg)
        {
            textBox1.AppendText(msg + Environment.NewLine);
            if (Configuration.Debug)
            {
                Utils.LogToFile(msg);
            }
        }

        private void Loading_Shown(object sender, EventArgs e)
        {
            this.debugLog("Read encryption key...");
            Configuration.EncryptionKey = Utils.GetEncryptionKey();
            RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey reg = currentUser.OpenSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, true);
            if (reg == null)
            {
                this.debugLog("Create registry...");
                reg = currentUser.CreateSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            }
            else
            {
                if (this.flushConfig)
                {
                    this.debugLog("Delete registry...");
                    reg.Close();
                    currentUser.DeleteSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                    this.debugLog("Create registry...");
                    reg = currentUser.CreateSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                }
            }
            //fontSize
            if (reg.GetValue("fontSize") == null)
            {
                this.debugLog("Create font size...");
                reg.SetValue("fontSize", Configuration.FontSize.ToString());
            }
            else
            {
                float fs;
                if (float.TryParse(reg.GetValue("fontSize").ToString(), out fs))
                {
                    this.debugLog("Load font size from registry: " + fs.ToString());
                    Configuration.FontSize = fs;
                }
                else
                {
                    this.debugLog("Problem parse font size from registry ...");
                }
            }
            //Debug
            if (reg.GetValue("debug") == null)
            {
                this.debugLog("Create debug...");
                reg.SetValue("debug", false.ToString());
            }
            else
            {
                this.debugLog("Load debug from registry: " + reg.GetValue("debug").ToString());
                Configuration.Debug = Convert.ToBoolean(reg.GetValue("debug"));
            }
            //checkUpdate
            if (reg.GetValue("checkUpdate") == null)
            {
                this.debugLog("Create check update...");
                reg.SetValue("checkUpdate", true.ToString());
            }
            else
            {
                this.debugLog("Load check update from registry: " + reg.GetValue("checkUpdate").ToString());
                Configuration.CheckUpdate = Convert.ToBoolean(reg.GetValue("checkUpdate"));
            }
            //silentUpdate
            if (reg.GetValue("silentUpdate") == null)
            {
                this.debugLog("Create silent update...");
                reg.SetValue("silentUpdate", false.ToString());
            }
            else
            {
                this.debugLog("Load silent update from registry: " + reg.GetValue("silentUpdate").ToString());
                Configuration.SilentUpdate = Convert.ToBoolean(reg.GetValue("silentUpdate"));
            }
            //updateServer
            if (reg.GetValue("updateServer") == null)
            {
                this.debugLog("Create update server...");
                reg.SetValue("updateServer", "https://raw.githubusercontent.com/kamilmroczkowski/ManageSieveKM/refs/heads/main/Releases/");
            }
            else
            {
                this.debugLog("Load update server from registry: " + reg.GetValue("updateServer").ToString());
                Configuration.ServerUpdate = reg.GetValue("updateServer").ToString();
            }
            //host
            if (reg.GetValue("host") == null)
            {
                this.debugLog("Create host...");
                reg.SetValue("host", "");
            }
            else
            {
                this.debugLog("Load host from registry: " + reg.GetValue("host").ToString());
                Configuration.Host = reg.GetValue("host").ToString();
            }
            //port
            if (reg.GetValue("port") == null)
            {
                this.debugLog("Create port...");
                reg.SetValue("port", "4190");
            }
            else
            {
                int port = 4190;
                if (int.TryParse(reg.GetValue("port").ToString(), out port))
                {
                    this.debugLog("Load port from registry: " + port.ToString());
                    Configuration.Port = port;
                }
                else
                {
                    this.debugLog("Problem parse port from registry...");
                }
            }
            //TLS
            if (reg.GetValue("tls") == null)
            {
                this.debugLog("Create TLS...");
                reg.SetValue("tls", true.ToString());
            }
            else
            {
                this.debugLog("Load TLS from registry: " + reg.GetValue("tls").ToString());
                Configuration.Tls = Convert.ToBoolean(reg.GetValue("tls"));
            }
            //Ignore Validate Certificate
            if (reg.GetValue("ignoreValidade") == null)
            {
                this.debugLog("Create ignore validade...");
                reg.SetValue("ignoreValidade", false.ToString());
            }
            else
            {
                this.debugLog("Load ignore validade from registry: " + reg.GetValue("ignoreValidade").ToString());
                Configuration.IgnoreCert = Convert.ToBoolean(reg.GetValue("ignoreValidade"));
            }
            //email
            if (reg.GetValue("email") == null)
            {
                this.debugLog("Create email...");
                reg.SetValue("email", "");
            }
            else
            {
                this.debugLog("Load email from registry: " + reg.GetValue("email").ToString());
                Configuration.Email = reg.GetValue("email").ToString();
            }
            //password
            if (reg.GetValue("password") == null)
            {
                this.debugLog("Create password...");
                reg.SetValue("password", "");
            }
            else
            {
                this.debugLog("Load password from registry...");
                Configuration.Password = reg.GetValue("password").ToString();
            }
            //showOnlyAutoresponder
            if (reg.GetValue("showOnlyAutoresponder") == null)
            {
                this.debugLog("Create show only autoresponder...");
                reg.SetValue("showOnlyAutoresponder", false.ToString());
            }
            else
            {
                this.debugLog("Load show only autoresponder from registry: " + reg.GetValue("showOnlyAutoresponder").ToString());
                Configuration.ShowOnlyAutoresponder = Convert.ToBoolean(reg.GetValue("showOnlyAutoresponder"));
            }
            //update
            if (Configuration.CheckUpdate)
            {
                this.debugLog("Check update...");
                string file0;
                try
                {
                    string version = this.webclient.DownloadString(Configuration.ServerUpdate + "version.txt").Trim();
                    this.debugLog("Check version in server: " + version);
                    if (System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() != version.Trim())
                    {
                        DialogResult dl = DialogResult.OK;
                        if (Configuration.SilentUpdate == false)
                        {
                            dl = MessageBox.Show("Release new version - apply update program?", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        }
                        if (dl == DialogResult.OK)
                        {
                            this.debugLog("My version (" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() + ") is diffrent... update.");
                            file0 = "ManageSieveKM.exe";
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + file0))
                            {
                                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + file0 + ".bak"))
                                {
                                    this.debugLog("Delete old file: " + AppDomain.CurrentDomain.BaseDirectory + file0 + ".bak");
                                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + file0 + ".bak");
                                }
                                this.debugLog("Move file: " + AppDomain.CurrentDomain.BaseDirectory + file0 + " to: " + file0 + ".bak");
                                File.Move(AppDomain.CurrentDomain.BaseDirectory + file0, AppDomain.CurrentDomain.BaseDirectory + file0 + ".bak");
                            }
                            this.debugLog("Download file from: " + Configuration.ServerUpdate + version + "/" + file0);
                            this.webclient.DownloadFile(new Uri(Configuration.ServerUpdate + version + "/" + file0), AppDomain.CurrentDomain.BaseDirectory + file0);
                            this.debugLog("Start new version file");
                            Process.Start(Application.ExecutablePath);
                            this.debugLog("Kill old version file");
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
                    this.debugLog("Update error: " + error);
                    MessageBox.Show("Update error: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Thread.Sleep(1000);
            this.Close();
        }
    }
}
