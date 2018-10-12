using Shared.Api.Schedule.Instance;
using Sxh.Business;
using Sxh.Business.Models;
using System;
using System.Threading.Tasks;

namespace Sxh.Server.Services
{
    public class TaskHeartbeats : TaskHeartbeat
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="domain">http domain</param>
        /// <param name="frequency">schedule excuting frequency in seconds</param>
        public TaskHeartbeats(string domain, int? frequency) : base(domain, frequency) { }

        public async override Task LogAsync(bool success, string msg)
        {
            try
            {
                BusinessCache.Clear();
                BusinessCache.Load();
            }
            catch (Exception)
            {
                //ignore
            }

            await LogProvider.LogAsync(msg, success ? LogType.Schedule : LogType.Error);
        }
    }
}
