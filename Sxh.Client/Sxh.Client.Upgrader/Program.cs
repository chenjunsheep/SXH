using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Worker = Sxh.Client.Upgrader.Business;

namespace Sxh.Client.Upgrader
{
    static class Program
    {
        static bool myLock;
        static Process curProcess = Process.GetCurrentProcess();
        static Mutex m = new Mutex(true, curProcess.MainModule.FileName.Replace(":", "").Replace(@"\", "") + "Sxh.Client.Upgrader", out myLock);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (myLock)
            {
                try
                {
                    args = new string[] { "Sxh.Client", "http://localhost:898" };

                    if (args == null || args.Length < 1)
                    {
                        throw new Exception("invalid parameters");
                    }
                    
                    var upgrader = new Worker.Upgrader(Application.StartupPath, args[0], args[1]);
                    if (upgrader.ServerSettings.Items.Count > 0)
                    {
                        var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                        var principal = new System.Security.Principal.WindowsPrincipal(identity);
                        if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                        {
                            Run(upgrader);
                        }
                        else
                        {
                            var result = Environment.GetEnvironmentVariable("systemdrive");
                            if (AppDomain.CurrentDomain.BaseDirectory.Contains(result))
                            {
                                var startInfo = new ProcessStartInfo
                                {
                                    FileName = Application.ExecutablePath,
                                    Verb = "runas",
                                    Arguments = $" {upgrader.ProgramName} {upgrader.ServerDomain}"
                                };
                                Process.Start(startInfo);
                            }
                            else
                            {
                                Run(upgrader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static void Run(Worker.Upgrader upgrader)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var winMain = new Main();
            winMain.UpgradeManager = upgrader;
            Application.Run(winMain);
        }
    }
}
