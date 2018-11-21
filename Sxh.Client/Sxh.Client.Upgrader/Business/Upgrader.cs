using ICSharpCode.SharpZipLib.Zip;
using Shared.Util;
using Shared.Util.Extension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using static Sxh.Shared.Settings.VersionUpdater;

namespace Sxh.Client.Upgrader.Business
{
    public class Upgrader
    {
        #region Property

        public delegate void UpdateProgess(Parameter para);
        public UpdateProgess OnUpdateProgess;
        public string TempPath
        {
            get
            {
                return Path.Combine(Environment.GetEnvironmentVariable("TEMP"), $@"Sxh.Client.Upgrader\temp\");
            }
        }
        public string BakPath
        {
            get
            {
                return Path.Combine(Environment.GetEnvironmentVariable("TEMP"), $@"Sxh.Client.Upgrader\bak\");
            }
        }

        private List<string> FilePersonal { get; set; }
        private List<string> FileReserve { get; set; }
        public string RootPath { get; private set; }
        public string HostProgram { get; private set; }
        public string ServerDomain { get; private set; }

        private ServerSettings _serverSettings;
        public ServerSettings ServerSettings
        {
            get { return _serverSettings ?? (_serverSettings = new ServerSettings()); }
            private set { _serverSettings = value; }
        }

        public string CurrentApplicationName { get; private set; }

        private ClientSettings _clientSettings;
        public ClientSettings ClientSettings
        {
            get { return _clientSettings ?? (_clientSettings = new ClientSettings()); }
            private set { _clientSettings = value; }
        }

        #endregion

        #region Constructor

        public Upgrader(string rootPath, string programName, string serverDomain)
        {
            RootPath = rootPath;
            HostProgram = programName;
            ServerDomain = serverDomain;
            CurrentApplicationName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            Init();
        }

        #endregion

        #region Public Method

        public void Excute()
        {
            KillProcess(0, 5);
            Backup(5, 20);
            DownLoad(20, 70);
            Upgrade(70, 95);
            ApplicationStartup(95, 100);
        }

        #endregion

        #region Private Method

        private void Init()
        {
            var bakInfo = new DirectoryInfo(BakPath);
            if (!bakInfo.Exists)
            {
                bakInfo.Create();
            }
            var tempInfo = new DirectoryInfo(TempPath);
            if (!tempInfo.Exists)
            {
                tempInfo.Create();
            }

            FilePersonal = new List<string>() { "account.xml", "proxySxh.xml", "proxyTzb.xml" };
            FileReserve = new List<string>() { "ICSharpCode.SharpZipLib.dll", CurrentApplicationName };

            ClientSettings.LoadXml(RootPath);
            ServerSettings = GetServerConfig(ServerDomain);
            ServerSettings = CheckVersion(ServerSettings, ClientSettings);
        }

        private static ServerSettings GetServerConfig(string serverHost)
        {
            var url = new Uri(serverHost).AddPath(ServerSettings.Namespaces.Config.VirtrualFolder).AddPath(ServerSettings.Namespaces.Config.PhysicalFile);
            using (var webClient = new WebClient())
            {
                var xml = webClient.DownloadString(url);
                var settings = new ServerSettings();
                settings.LoadXml(xml);
                return settings;
            }
        }

        private ServerSettings CheckVersion(ServerSettings serverSettings, ClientSettings clientSettings)
        {
            if (clientSettings == null || serverSettings == null) return serverSettings;

            var ret = new ServerSettings();
            ret.TargetServer = ServerSettings.TargetServer;

            var versionLocal = TypeParser.GetStringValue(clientSettings.LocalVersion).Split('.');
            foreach (var serverSettingItem in serverSettings.Items)
            {
                var versionServer = TypeParser.GetStringValue(serverSettingItem.ReleaseVersion).Split('.');

                if (versionLocal.Length != versionServer.Length)
                {
                    ret.Items.Add(serverSettingItem);
                    continue;
                }

                for (var i = 0; i < versionLocal.Length; i++)
                {
                    var valLocal = TypeParser.GetInt32Value(versionLocal[i]);
                    var valServer = TypeParser.GetInt32Value(versionServer[i]);
                    if (valLocal < valServer)
                    {
                        ret.Items.Add(serverSettingItem);
                        break;
                    }
                }
            }
            return ret;
        }

        private void KillProcess(int procsssFrom, int processTo)
        {
            var processes = Process.GetProcessesByName(HostProgram);
            foreach (Process p in processes)
            {
                p.Kill();
                p.Close();
            }
            OnUpdateProgess?.Invoke(Parameter.Create(processTo, "host application is shutdown"));

            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception($"failed to kill process {HostProgram}. {ex.Message}");
            }
        }

        private void Backup(int procsssFrom, int processTo)
        {
            try
            {
                OnUpdateProgess?.Invoke(Parameter.Create(procsssFrom++, "start to backup files"));
                DeleteFiles(BakPath, null);

                var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                foreach (var item in di.GetFiles())
                {
                    if (item.Name != CurrentApplicationName)
                    {
                        File.Copy(item.FullName, $"{BakPath}{item.Name}", true);
                        OnUpdateProgess?.Invoke(Parameter.Create(procsssFrom++, $"copied file {item.FullName}"));
                    }
                }

                foreach (var item in di.GetDirectories())
                {
                    CopyDirectory(item.FullName, BakPath);
                    OnUpdateProgess?.Invoke(Parameter.Create(procsssFrom++, $"copied directory {item.FullName}"));
                }

                OnUpdateProgess?.Invoke(Parameter.Create(processTo, "backup successed"));
            }
            catch (Exception ex)
            {
                throw new Exception($"failed to backup. {ex.Message}", ex.InnerException);
            }
        }

        private void DownLoad(int procsssFrom, int processTo)
        {
            using (var web = new WebClient())
            {
                for (var i = 0; i < ServerSettings.Items.Count; i++)
                {
                    var item = ServerSettings.Items[i];
                    var uri = new Uri($"{ServerSettings.TargetServer}/{ServerSettings.Namespaces.Config.VirtrualFolder}/{item.ReleaseFileServer}");
                    try
                    {
                        OnUpdateProgess?.Invoke(Parameter.Create(procsssFrom + (processTo - procsssFrom) * (i + 1) / ServerSettings.Items.Count, $"downloading from {uri.AbsoluteUri}"));
                        web.DownloadFile(uri, $"{TempPath}{item.ReleaseFileClient}");
                        OnUpdateProgess?.Invoke(Parameter.Create(processTo, $"downloading successed"));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"failed to download from {uri.AbsoluteUri}. {ex.Message}", ex.InnerException);
                    }
                }
            }
        }

        private void Upgrade(int procsssFrom, int processTo)
        {
            var diff = (processTo - procsssFrom) / ServerSettings.Items.Count;
            foreach (var item in ServerSettings.Items)
            {
                var subDiff = diff / 4;
                try
                {
                    OnUpdateProgess?.Invoke(Parameter.Create(procsssFrom + subDiff * 1, $"removing files out of date..."));
                    DeleteFiles(AppDomain.CurrentDomain.BaseDirectory, FileReserve);

                    OnUpdateProgess?.Invoke(Parameter.Create(procsssFrom + subDiff * 2, $"decompressing installation files..."));
                    var path = $"{TempPath}{item.ReleaseFileClient}";
                    var fastZip = new FastZip();
                    fastZip.ExtractZip(path, AppDomain.CurrentDomain.BaseDirectory, null);
                    OnUpdateProgess?.Invoke(Parameter.Create(procsssFrom + subDiff * 3, $"installation files is ready"));

                    ClientSettings.LocalVersion = item.ReleaseVersion;
                    ClientSettings.SaveToXml(AppDomain.CurrentDomain.BaseDirectory);
                }
                catch (Exception ex)
                {
                    Restore();
                    throw new Exception($"failed to upgrade application. {ex.Message}", ex.InnerException);
                }
                finally
                {
                    DeleteFiles(TempPath, null);
                    RestorePersonalSettings();
                    OnUpdateProgess?.Invoke(Parameter.Create(procsssFrom + subDiff * 4, $"configurated local settings"));
                }
            }
            OnUpdateProgess?.Invoke(Parameter.Create(processTo, $"application upgraded successfully"));
        }

        private void ApplicationStartup(int procsssFrom, int processTo)
        {
            try
            {
                var targetSetting = ServerSettings.Items.LastOrDefault();
                if (targetSetting != null)
                {
                    var startInfo = targetSetting.ApplicationStart.Split(',');
                    if (startInfo.Length > 0)
                    {
                        foreach (var item in startInfo)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                OnUpdateProgess?.Invoke(Parameter.Create(procsssFrom, $"startuping {item}"));
                                var processStartInfo = new ProcessStartInfo()
                                {
                                    FileName = item,
                                    Arguments = string.Empty
                                };
                                Process.Start(processStartInfo);
                            }
                        }
                    }
                }
                OnUpdateProgess?.Invoke(Parameter.Create(processTo, "done"));
            }
            catch (Exception ex)
            {
                throw new Exception($"failed to restart application. {ex.Message}", ex.InnerException);
            }
        }

        private void Restore()
        {
            DeleteFiles(AppDomain.CurrentDomain.BaseDirectory, FileReserve);
            CopyDirectory(BakPath, AppDomain.CurrentDomain.BaseDirectory);
        }

        private void DeleteFiles(string folderPath, List<string> reservedFiles)
        {
            var di = new DirectoryInfo(folderPath);
            if (di.Exists)
            {
                foreach (var item in di.GetFiles())
                {
                    if (reservedFiles != null && reservedFiles.Contains(item.Name))
                    {
                        continue;
                    }

                    try
                    {
                        File.Delete(item.FullName);
                    }
                    catch { }
                }

                foreach (var item in di.GetDirectories())
                {
                    try
                    {
                        item.Delete(true);
                    }
                    catch { }
                }
            }
        }

        private void RestorePersonalSettings()
        {
            foreach (var settings in FilePersonal)
            {
                var fileBak = Path.Combine(BakPath, settings);
                if (File.Exists(fileBak))
                {
                    try
                    {
                        File.Copy(fileBak, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings), true);
                    }
                    catch { }
                }
            }
        }

        private void CopyDirectory(string srcdir, string desdir)
        {
            var folderName = srcdir.Substring(srcdir.LastIndexOf("\\") + 1);
            var desfolderdir = $"{desdir}\\{folderName}";
            if (desdir.LastIndexOf("\\") == (desdir.Length - 1))
            {
                desfolderdir = $"{desdir}{folderName}";
            }
            var filenames = Directory.GetFileSystemEntries(srcdir);
            foreach (string file in filenames)
            {
                if (Directory.Exists(file))
                {
                    var currentdir = $"{desfolderdir}\\{file.Substring(file.LastIndexOf("\\") + 1)}";
                    if (!Directory.Exists(currentdir))
                    {
                        try
                        {
                            Directory.CreateDirectory(currentdir);
                        }
                        catch { }
                    }
                    CopyDirectory(file, desfolderdir);
                }
                else
                {
                    var srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                    srcfileName = $"{desfolderdir}\\{srcfileName}";
                    if (!Directory.Exists(desfolderdir))
                    {
                        try
                        {
                            Directory.CreateDirectory(desfolderdir);
                        }
                        catch { }
                    }
                    try
                    {
                        File.Copy(file, srcfileName, true);
                    }
                    catch { }
                }
            }
        }

        #endregion

        #region Class

        public class Parameter
        {
            public int Step { get; set; }
            public string Message { get; set; }

            public static Parameter Create(int step, string message)
            {
                var para = new Parameter();
                para.Step = step;
                para.Message = message;
                return para;
            }
        }

        #endregion
    }
}
