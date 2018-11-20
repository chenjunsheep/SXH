using System;
using System.IO;

namespace Sxh.Shared
{
    public static class LogProvider
    {
        static string temp = AppDomain.CurrentDomain.BaseDirectory;
        public static void AddLog(LogType logType, string value)
        {
            if (!Directory.Exists(Path.Combine(temp, @"log\")))
            {
                var directoryInfo = new DirectoryInfo(Path.Combine(temp, @"log\"));
                directoryInfo.Create();
            }
            var fileName = GetFileName(logType);
            using (StreamWriter sw = File.AppendText(Path.Combine(temp, $@"log\{fileName}")))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} {value}");
            }
        }

        private static string GetFileName(LogType logType)
        {
            switch (logType)
            {
                case LogType.Upgrade:
                    return "update.log";
                default:
                    return "common.log";
            }
        }

        public enum LogType
        {
            Normal,
            Upgrade,
        }
    }
}
