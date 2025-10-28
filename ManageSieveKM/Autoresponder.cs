using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ManageSieveKM
{
    public partial class Autoresponder : Form
    {
        private string newScript, oldScript;
        private int lastRule = 0;
        private bool ifAutoresponder = false;
        public Autoresponder(string script, int lastRule)
        {
            InitializeComponent();
            this.oldScript = script;
            string[] scripts = script.Split(new string[] { "# rule:[" }, StringSplitOptions.None);
            foreach (string s in scripts)
            {
                if (s.IndexOf("require [") != -1)
                {
                    continue;
                }
                else
                {
                    if (s.IndexOf("vacation :subject") != -1)
                    {
                        int i = s.IndexOf("]\r\n");
                        string nameRule = s.Substring(0, i);
                        cbRules.Items.Add(nameRule);
                        ifAutoresponder = true;
                    }
                }
            }
            if (ifAutoresponder == false)
            {
                cbRules.Items.Add("Autoresponder");
            }
            cbRules.SelectedIndex = 0;
        }

        public string NewScript { get => newScript; set => newScript = value; }
        public int LastRule { get => lastRule; set => lastRule = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbSubject.Text.Trim() == "" || tbBody.Text.Trim() == "")
            {
                MessageBox.Show("Please write subject and body!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Date from is grather date to!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbCopy.Text.Trim() != "")
            {
                bool email = false;
                try
                {
                    MailAddress m = new MailAddress(tbCopy.Text.Trim());
                    email = true;
                }
                catch
                {
                    email = false;
                }
                if (email == false)
                {
                    MessageBox.Show("Email address in copy to is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string autoresponder = "";
            autoresponder += "# rule:[" + ((cbRules.Text.Trim() == "") ? "Autoresponder" : cbRules.Text) + "]" + Environment.NewLine;
            autoresponder += "if allof(currentdate :value \"ge\" \"iso8601\" \"" +
                Utils.DateTime2ISO(dtpFrom.Value).Replace(" ", "T") +
                "\", currentdate :value \"le\" \"iso8601\" \"" +
                Utils.DateTime2ISO(dtpTo.Value).Replace(" ", "T") + "\")" + Environment.NewLine;
            autoresponder += "{" + Environment.NewLine;
            autoresponder += "\tvacation :subject \"" + tbSubject.Text + "\" text:" + Environment.NewLine;
            autoresponder += tbBody.Text + Environment.NewLine;
            autoresponder += "." + Environment.NewLine;
            autoresponder += ";" + Environment.NewLine;
            if (tbCopy.Text.Trim() != "")
            {
                autoresponder += "\tredirect :copy \"" + tbCopy.Text + "\";" + Environment.NewLine;
            }
            autoresponder += "}" + Environment.NewLine;
            this.newScript = "";
            if (ifAutoresponder == false)
            {
                this.newScript = "require [\"date\",\"fileinto\",\"relational\",\"vacation\"];" + Environment.NewLine;
                this.newScript += this.oldScript;
                this.newScript += autoresponder;
            }
            else
            {
                int i = this.oldScript.IndexOf("# rule:[" + cbRules.Text + "]\r\n");
                int i2 = this.oldScript.IndexOf("}\r\n", i);
                this.newScript = this.oldScript.Substring(0, i) + autoresponder +
                    this.oldScript.Substring(i2 + 2, this.oldScript.Length - i2 - 2);
            }
            this.LastRule = cbRules.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }

        private void cbRules_TextChanged(object sender, EventArgs e)
        {
            if (cbRules.Text != "")
            {
                string[] scripts = oldScript.Split(new string[] { "# rule:[" }, StringSplitOptions.None);
                foreach (string s in scripts)
                {
                    //if (s.Length > 9 && s.Substring(0, 9) == "require [")
                    if (s.IndexOf("require [") != -1)
                    {
                        continue;
                    }
                    else
                    {
                        int i = s.IndexOf("]" + Environment.NewLine);
                        string nameRule = s.Substring(0, i);
                        if (nameRule == cbRules.Text)
                        {
                            string[] rule = s.Split(new string[] { "vacation :subject" }, StringSplitOptions.None);
                            if (rule.Length > 1)
                            {
                                string[] subjectBody;
                                if (rule[1].IndexOf("\" text:") == -1)
                                {
                                    subjectBody = rule[1].Split(new string[] { "\" \"" }, StringSplitOptions.None);
                                    tbSubject.Text = subjectBody[0].Substring(2, subjectBody[0].Length - 2);
                                }
                                else
                                {
                                    subjectBody = rule[1].Split(new string[] { "\" text:" }, StringSplitOptions.None);
                                    tbSubject.Text = subjectBody[0].Substring(2, subjectBody[0].Length - 2);
                                }
                                int ir = subjectBody[1].IndexOf("redirect");
                                if (ir == -1)
                                {
                                    tbBody.Text = subjectBody[1].Substring(2, subjectBody[1].Length - 13).Trim();
                                }
                                else
                                {
                                    string[] body = subjectBody[1].Split(new string[] { "redirect :copy" }, StringSplitOptions.None);
                                    tbBody.Text = body[0].Substring(2, ir - 11);
                                    tbCopy.Text = body[1].Substring(2, body[1].Length - 9);
                                }
                                string[] dateTime = rule[0].Split(new string[] { "\"iso8601\"" }, StringSplitOptions.None);
                                if (dateTime.Length > 1)
                                {
                                    dtpFrom.Value = DateTime.ParseExact(dateTime[1].Substring(2, 16).Replace("T", " "), "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                                    dtpTo.Value = DateTime.ParseExact(dateTime[2].Substring(2, 16).Replace("T", " "), "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
