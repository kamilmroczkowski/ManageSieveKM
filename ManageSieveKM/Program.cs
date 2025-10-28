using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            bool flushConfig = false;
            if (args.Length > 0 )
            {
                if (args[0] == "/flushConfig")
                {
                    flushConfig = true;
                }
            }
            Application.Run(new Form1(flushConfig));
        }
    }
}
