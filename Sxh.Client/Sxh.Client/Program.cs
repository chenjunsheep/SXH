using Sxh.Client.Business;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Sxh.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AutoUpgrade();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        private static void AutoUpgrade()
        {
            const string upgraderName = "Sxh.Client.Upgrader";
            try
            {
                var processes = Process.GetProcessesByName(upgraderName);
                foreach (Process p in processes)
                {
                    p.Kill();
                    p.Close();
                }
            }
            catch { }

            var strUpgrader = $"{upgraderName}.exe";
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}{strUpgrader}";
            if (File.Exists(path))
            {
                var processStartInfo = new ProcessStartInfo()
                {
                    FileName = strUpgrader,
                    Arguments = $" Sxh.Client http://{AppSetting.Instance.Server}"
                };
                var proc = Process.Start(processStartInfo);
                if (proc != null)
                {
                    proc.WaitForExit();
                }
            }
        }
    }
}
