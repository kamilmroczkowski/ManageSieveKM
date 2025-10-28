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
    public partial class FormT : Form
    {
        private RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
        private RegistryKey reg;
        private float fontSize = 12;

        public FormT()
        {
            InitializeComponent();
            reg = currentUser.OpenSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, true);
            if (reg == null)
            {
                reg = currentUser.CreateSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            }
            //fontSize
            if (reg.GetValue("fontSize") == null)
            {
                reg.SetValue("fontSize", "12");
                this.fontSize = 12;
            }
            else
            {
                float fs = 12;
                if (float.TryParse(reg.GetValue("fontSize").ToString(), out fs))
                {

                }
                this.fontSize = fs;
            }
        }

        private void ControlsCheck(Control c)
        {
            float sizeF = 0;
            foreach (Control c1 in c.Controls)
            {
                if (c1.Font.Size != this.Font.Size || c1.Font.Style != this.Font.Style)
                {
                    sizeF = this.fontSize - 8 + c1.Font.Size;
                    c1.Font = new Font(c1.Font.FontFamily, sizeF, c1.Font.Style);
                }
                if (c1.Controls.Count > 0)
                {
                    this.ControlsCheck(c1);
                }
            }
        }

        private void FormT_Load(object sender, EventArgs e)
        {
            this.ControlsCheck(this);
            this.Font = new Font(this.Font.FontFamily, this.fontSize, this.Font.Style);
        }
    }
}
