using Sxh.Business.DbProxy;
using Sxh.Business.Models;
using Sxh.Db.Models;
using System;
using System.Threading.Tasks;

namespace Sxh.Server.Services
{
    public class LogProvider
    {
        public static async Task LogAsync(string msg, LogType logType)
        {
            try
            {
                using (var db = DbContextFactory.CreateSxhContext())
                {
                    var log = new Logs();
                    log.LogType = (int)logType;
                    log.Memo = msg;
                    log.Date = DateTime.Now;
                    await db.Logs.AddAsync(log);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception) { }
        }
    }
}
