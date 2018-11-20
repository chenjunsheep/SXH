using ICSharpCode.SharpZipLib.Zip;
using Shared.Util;
using Shared.Util.Extension;
using Sxh.Shared;
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

        public delegate void UpdateProgess(double data);
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

        private List<string> FilePersonal = new List<string>() { "account.xml", "proxySxh.xml", "proxyTzb.xml" };
        private List<string> FileReserve = new List<string>() { "ICSharpCode.SharpZipLib.dll" };
        public string RootPath { get; private set; }
        public string ProgramName { get; private set; }
        public string ServerDomain { get; private set; }

        private ServerSettings _serverSettings;
        public ServerSettings ServerSettings
        {
            get { return _serverSettings ?? (_serverSettings = new ServerSettings()); }
            private set { _serverSettings = value; }
        }

        public string MainName { get; private set; }

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
            ProgramName = programName;
            ServerDomain = serverDomain;
            MainName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            Init();
            ServerSettings = CheckVersion(ServerSettings, ClientSettings);
        }

        #endregion

        #region Public Method

        public bool Excute()
        {
            //KillProcessExist();
            Backup();
            DownLoad();
            Update();
            AppRiseUp();
            return true;
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

            ClientSettings.LoadXml(RootPath);
            ServerSettings = GetServerConfig(ServerDomain);
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

        private void KillProcessExist()
        {
            var processes = Process.GetProcessesByName(ProgramName);
            foreach (Process p in processes)
            {
                p.Kill();
                p.Close();
            }
        }

        private void Backup()
        {
            try
            {
                LogProvider.AddLog(LogProvider.LogType.Upgrade, "upgrader：backup...");
                DeleteBackupFiles();
                var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                foreach (var item in di.GetFiles())
                {
                    if (item.Name != MainName)
                    {
                        File.Copy(item.FullName, $"{BakPath}{item.Name}", true);
                    }
                }

                foreach (var item in di.GetDirectories())
                {
                    CopyDirectory(item.FullName, BakPath);
                }
                LogProvider.AddLog(LogProvider.LogType.Upgrade, "upgrader：backup successfully");
                OnUpdateProgess?.Invoke(20);

            }
            catch (Exception ex)
            {
                LogProvider.AddLog(LogProvider.LogType.Upgrade, $"upgrader：failed to backup. {ex.Message}");
                throw ex;
            }
        }

        private void DownLoad()
        {
            using (var web = new WebClient())
            {
                for (var i = 0; i < ServerSettings.Items.Count; i++)
                {
                    var item = ServerSettings.Items[i];
                    try
                    {
                        LogProvider.AddLog(LogProvider.LogType.Upgrade, $"upgrader：downloading file {item.ReleaseFileClient}");
                        web.DownloadFile(new Uri($"{ServerSettings.TargetServer}/{ServerSettings.Namespaces.Config.VirtrualFolder}/{item.ReleaseFileServer}"), $"{TempPath}{item.ReleaseFileClient}");
                        OnUpdateProgess?.Invoke(60 / ServerSettings.Items.Count * (i + 1));
                    }
                    catch (Exception ex)
                    {
                        LogProvider.AddLog(LogProvider.LogType.Upgrade, $"upgrader：failed to download files. {ex.Message}");
                        throw ex;
                    }
                }
            }
        }

        private void Update()
        {
            foreach (var item in ServerSettings.Items)
            {
                try
                {
                    DeleteLocalFiles();
                    var path = $"{TempPath}{item.ReleaseFileClient}";

                    LogProvider.AddLog(LogProvider.LogType.Upgrade, $"upgrader：unzip {item.ReleaseFileClient}");

                    var fastZip = new FastZip();
                    fastZip.ExtractZip(path, AppDomain.CurrentDomain.BaseDirectory, null);
                    
                    LogProvider.AddLog(LogProvider.LogType.Upgrade, "upgrader：unzip successfully");

                    ClientSettings.LocalVersion = item.ReleaseVersion;
                    ClientSettings.SaveToXml(AppDomain.CurrentDomain.BaseDirectory);
                }
                catch (Exception ex)
                {
                    LogProvider.AddLog(LogProvider.LogType.Upgrade, $"upgrader：{ex.Message}");
                    LogProvider.AddLog(LogProvider.LogType.Upgrade, $"upgrader：upgrading failed, rollback");
                    Restore();
                    break;
                }
                finally
                {
                    //DeleteTempFile(item.ReleaseFileClient);
                    RestorePersonalSettings();
                }
            }
            OnUpdateProgess?.Invoke(98);
        }

        private void AppRiseUp()
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
                            LogProvider.AddLog(LogProvider.LogType.Upgrade, $"upgrader：startup {item}");
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
            OnUpdateProgess?.Invoke(100);
        }

        private void DeleteLocalFiles()
        {
            var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            foreach (var item in di.GetFiles())
            {
                if (item.Name != MainName && !FileReserve.Contains(item.Name))
                {
                    try
                    {
                        File.Delete(item.FullName);
                    }
                    catch (Exception)
                    {
                        //ignore
                    }
                }
            }
            foreach (var item in di.GetDirectories())
            {
                try
                {
                    item.Delete(true);
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        private void DeleteBackupFiles()
        {
            var di = new DirectoryInfo(BakPath);
            foreach (var item in di.GetFiles())
            {
                if (item.Name != MainName)
                {
                    if (item.Name != ClientSettings.Namespaces.Config.PhysicalFile)
                    {
                        try
                        {
                            File.Delete(item.FullName);
                        }
                        catch (Exception)
                        {
                            //ignore
                        }
                    }
                }
            }
            foreach (var item in di.GetDirectories())
            {
                try
                {
                    item.Delete(true);
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        private void DeleteTempFile(string fileName)
        {
            try
            {
                var file = new FileInfo($"{TempPath}{fileName}");
                file.Delete();
            }
            catch (Exception)
            {
                //ignore
            }
        }

        private void Restore()
        {
            DeleteLocalFiles();
            CopyDirectory(BakPath, AppDomain.CurrentDomain.BaseDirectory);
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
                    catch (Exception)
                    {
                        //ignore
                    }
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
                        catch (Exception)
                        {
                            //ignore
                        }
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
                        catch (Exception)
                        {
                            //ignore
                        }
                    }
                    try
                    {
                        File.Copy(file, srcfileName, true);
                    }
                    catch (Exception)
                    {
                        //ignore
                    }
                }
            }
        }

        #endregion
    }
}
