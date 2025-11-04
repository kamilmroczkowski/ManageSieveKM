using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ManageSieveKM
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String thisprocessname = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            {
                MessageBox.Show("Application is now running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool flushConfig = false;
            if (args.Length > 0)
            {
                if (args[0] == "/flushConfig")
                {
                    flushConfig = false;
                }
            }
            Application.Run(new Form1(flushConfig));
        }
    }
}
