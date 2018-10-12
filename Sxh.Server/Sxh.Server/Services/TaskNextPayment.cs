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

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();

            if (!string.IsNullOrEmpty(Domain))
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(Domain);
                    client.BaseAddress = baseAddress;
                    var response = await client.GetAsync(baseAddress.AddPath("/api/Calculate/GeneratePaymentPlan"));
                    if (response.IsSuccessStatusCode)
                    {
                        await LogProvider.LogAsync(Schedule, LogType.Schedule);
                    }
                    else
                    {
                        await LogProvider.LogAsync($"[{(int)response.StatusCode} {response.StatusCode}] {Schedule}", LogType.Error);
                    }
                }
            }
        }
    }
}
