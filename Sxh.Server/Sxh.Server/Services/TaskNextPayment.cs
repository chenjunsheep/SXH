using Shared.Api.Schedule;
using Shared.Util.Extension;
using Sxh.Business.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sxh.Server.Services
{
    public class TaskNextPayment : IScheduledTask
    {
        private string Domain { get; set; }
        /// <summary>
        /// frequency in seconds
        /// </summary>
        public int? Frequency { get; set; }

        public string Schedule { get { return "Calculate Next Payment"; } }

        public TaskNextPayment(string domain, int? frequency)
        {
            Domain = domain;
            Frequency = frequency;
        }

        public Task ExecuteAsync(CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(Domain))
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(Domain);
                    client.BaseAddress = baseAddress;
                    var response = client.GetAsync(baseAddress.AddPath("/api/Calculate/GeneratePaymentPlan")).Result;
                    LogProvider.Log(Schedule, LogType.Schedule);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
