using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using Sxh.Client.Business.Model;

namespace Sxh.Client.Business.Proxy
{
    public class ProxySearch : ProxyBase
    {
        public async Task<ClientPortionTransferList> SearchAsync(CookieCollection tokenOffical, Parameter filter)
        {
            var ret = new ClientPortionTransferList();

            if (tokenOffical != null && filter != null)
            {
                var cookieJar = new CookieContainer();
                using (var handler = new HttpClientHandler
                {
                    CookieContainer = cookieJar,
                    UseCookies = true,
                })
                {
                    using (var client = CreateHttpClient(handler))
                    {
                        var formData = new FormUrlEncodedContent(new[] {
                            new KeyValuePair<string, string>("title", filter.Keyword),
                            new KeyValuePair<string, string>("currentPage", "1"),
                            new KeyValuePair<string, string>("maxRowsPerPage", "15"),
                            new KeyValuePair<string, string>("projectType", string.Empty),
                            new KeyValuePair<string, string>("remainingCount", string.Empty),
                            new KeyValuePair<string, string>("repayStrategy", string.Empty),
                            new KeyValuePair<string, string>("hasTransfering", "true"),
                            new KeyValuePair<string, string>("hasAcquiring", "false"),
                            new KeyValuePair<string, string>("noDealing", "false"),
                            new KeyValuePair<string, string>("orderBy", "minTransferingRate"),
                            new KeyValuePair<string, string>("orderType", "desc"),
                        });

                        var Uri = CreateUri("/portionTransfer/list");

                        foreach (Cookie token in tokenOffical)
                        {
                            cookieJar.Add(Uri, new Cookie(token.Name, token.Value));
                        }

                        var response = await client.PostAsync(Uri, formData);
                        response.EnsureSuccessStatusCode();

                        var jsonString = await response.Content.ReadAsStringAsync();
                        ret = JsonConvert.DeserializeObject<ClientPortionTransferList>(jsonString);
                    }
                }
            }

            return ret;
        }

        public static string GetPathTranserDetail(int projectId)
        {
            return CreateUri($"/portionTransferDetail?projectId={projectId}").AbsoluteUri;
        }

        public class Parameter
        {
            public string Keyword { get; set; }

            public static Parameter Create(string keywords)
            {
                return new Parameter() { Keyword = keywords };
            }
        }
    }
}
