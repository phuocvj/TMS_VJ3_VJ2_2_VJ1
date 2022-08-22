using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MAIN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            int width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            while(width!=1920 && height != 1080)
            {
                Thread.Sleep(1000);
            }
            Application.Run(new RunINE());
         //   Application.Run(new FormFlash());
        }
    }
}
