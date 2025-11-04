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
        public FormT()
        {
            InitializeComponent();
        }

        private void ControlsCheck(Control c)
        {
            float sizeF = 0;
            foreach (Control c1 in c.Controls)
            {
                if (c1.Font.Size != this.Font.Size || c1.Font.Style != this.Font.Style)
                {
                    sizeF = Configuration.FontSize - 8 + c1.Font.Size;
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
            this.Font = new Font(this.Font.FontFamily, Configuration.FontSize, this.Font.Style);
        }
    }
}
