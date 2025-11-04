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
    public partial class Autoresponder : FormT
    {
        private string newScript;
        private bool ifAutoresponder = false;
        private DataTable dtRules = new DataTable();
        List<string> modules = new List<string>() { "copy", "date", "fileinto", "imap4flags", "relational", "vacation" };

        public Autoresponder(string script)
        {
            InitializeComponent();
            int i, i2;
            dtRules.Columns.Add("name");
            dtRules.Columns.Add("body");
            dtRules.Columns.Add("vacation");
            string name, body, vacation;
            string[] scripts = script.Split(new string[] { "# rule:[" }, StringSplitOptions.None);
            foreach (string s in scripts)
            {
                i2 = s.IndexOf("require [");
                if (i2 != -1)
                {
                    i = s.IndexOf("\"];", i2);
                    foreach(string s2 in s.Substring(i2 + 9, i - i2 - 8).Split(','))
                    {
                        if (modules.Contains(s2.Trim('"')) == false)
                        {
                            modules.Add(s2.Trim('"'));
                        }
                    }
                }
                else
                {
                    i = s.IndexOf("]\r\n");
                    if (i != -1)
                    {
                        name = s.Substring(0, i);
                        body = s.Substring(i + 3, s.Length - i - 5);
                        vacation = "0";
                        if (s.IndexOf("vacation :subject") != -1)
                        {
                            cbRules.Items.Add(name);
                            ifAutoresponder = true;
                            vacation = "1";
                        }
                        dtRules.Rows.Add(name, vacation, body);
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
            autoresponder += "# rule:[" + cbRules.Text + "]" + Environment.NewLine;
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

            this.newScript = "require [";
            foreach(string s in modules)
            {
                this.newScript += "\"" + s + "\",";
            }
            this.newScript = this.newScript.Trim(',');
            this.newScript += "];" + Environment.NewLine;
            bool existsR = false;
            foreach(DataRow dr in dtRules.Rows)
            {
                if (dr[0].ToString() == cbRules.Text)
                {
                    this.newScript += autoresponder;
                    existsR = true;
                }
                else
                {
                    this.newScript += "# rule:[" + dr[0].ToString() + "]" + Environment.NewLine;
                    this.newScript += dr[2].ToString() + Environment.NewLine;
                }
            }
            if (existsR == false)
            {
                this.newScript += autoresponder;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void cbRules_TextChanged(object sender, EventArgs e)
        {
            if (cbRules.Text != "")
            {
                foreach(DataRow dr in dtRules.Rows)
                {
                    if (dr[0].ToString() == cbRules.Text && dr[1].ToString() == "1")
                    {
                        string[] subjectBody;
                        string body0 = dr[2].ToString();
                        string[] rule = body0.Split(new string[] { "vacation :subject" }, StringSplitOptions.None);
                        if (body0.IndexOf("\" text:") == -1)
                        {
                            subjectBody = rule[1].Split(new string[] { "\" \"" }, StringSplitOptions.None);
                        }
                        else
                        {
                            subjectBody = rule[1].Split(new string[] { "\" text:" }, StringSplitOptions.None);
                        }
                        tbSubject.Text = subjectBody[0].Substring(2, subjectBody[0].Length - 2);
                        int ir = subjectBody[1].IndexOf("redirect");
                        if (ir == -1)
                        {
                            tbBody.Text = subjectBody[1].Substring(2, subjectBody[1].Length - 11).Trim();
                        }
                        else
                        {
                            string[] body = subjectBody[1].Split(new string[] { "redirect :copy" }, StringSplitOptions.None);
                            tbBody.Text = body[0].Substring(2, ir - 11);
                            tbCopy.Text = body[1].Trim().Substring(1, body[1].Length - 5);
                        }
                        string[] dateTime = body0.Split(new string[] { "\"iso8601\"" }, StringSplitOptions.None);
                        if (dateTime.Length > 1)
                        {
                            dtpFrom.Value = DateTime.ParseExact(dateTime[1].Substring(2, 16).Replace("T", " "), "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                            dtpTo.Value = DateTime.ParseExact(dateTime[2].Substring(2, 16).Replace("T", " "), "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        break;
                    }
                }
            }
        }
    }
}
