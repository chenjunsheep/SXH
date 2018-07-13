using Sxh.Business.Models;
using System;

namespace Sxh.Server.Services
{
    public class LogProvider
    {
        public static void Log(string msg, LogType logType)
        {
            try
            {
                //var log = new Logs();
                //log.LogType = (int)logType;
                //log.Memo = msg;
                //log.Date = DateTime.Now;

            }
            catch (Exception) { }
        }
    }
}
