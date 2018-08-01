using Newtonsoft.Json;
using Shared.Util.Model;
using Sxh.Client.Business.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyProjectReverse : ProxyBase
    {
        public async Task<ClientProjectReverseList> SearchAsync(CookieCollection tokenOffical)
        {
            var ret = new ClientProjectReverseList();

            if (tokenOffical != null)
            {
                var cookieJar = new CookieContainer();
                using (var handler = new HttpClientHandler
                {
                    CookieContainer = cookieJar,
                    UseCookies = true,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                })
                {
                    using (var client = CreateHttpClient(AppSetting.Instance.HostTzb, handler))
                    {
                        var formData = new FormUrlEncodedContent(new[] {
                            new KeyValuePair<string, string>("periodType", "ALL"),
                            new KeyValuePair<string, string>("strategy", "ALL"),
                            new KeyValuePair<string, string>("habit", "ALL"),
                            new KeyValuePair<string, string>("complexOrder", "RATE_ASC"),
                            new KeyValuePair<string, string>("currentPage", "1"),
                        });

                        var uri = CreateUri($"/project/tzbig/findProjectReverseOnPage", AppSetting.Instance.HostTzb, HttpSchema.HTTPS);

                        foreach (Cookie token in tokenOffical)
                        {
                            cookieJar.Add(uri, new Cookie(token.Name, token.Value));
                        }

                        var response = await client.PostAsync(uri, formData);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            ret = JsonConvert.DeserializeObject<ClientProjectReverseList>(jsonString);
                        }
                    }
                }
            }

            return ret;
        }
    }
}
