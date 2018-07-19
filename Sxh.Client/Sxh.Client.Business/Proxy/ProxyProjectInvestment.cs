using Newtonsoft.Json;
using Shared.Util.Extension;
using Shared.Util.Model;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.Util;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyProjectInvestment : ProxyBase
    {
        public async Task<ClientProjectInvestmentList> SearchAsync(CookieCollection tokenOffical, Parameter filter)
        {
            var ret = new ClientProjectInvestmentList();

            if (tokenOffical != null && filter != null)
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
                        var uri = CreateUri($"/project/tzbig/findProjectOnInvestmentPage?{filter.GetQuery()}", AppSetting.Instance.HostTzb, HttpSchema.HTTPS);

                        foreach (Cookie token in tokenOffical)
                        {
                            cookieJar.Add(uri, new Cookie(token.Name, token.Value));
                        }

                        var response = await client.GetAsync(uri);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            ret = JsonConvert.DeserializeObject<ClientProjectInvestmentList>(jsonString);
                        }
                    }
                }
            }

            return ret;
        }

        public class Parameter
        {
            public PeriodType PeriodType { get; set; }

            public string GetQuery()
            {
                return $"projectType=ALL&periodType={PeriodType.ConvertToQueryValue()}&strategy=ALL&complexOrder=nhhbl1&currentPage=1&_ts={TimeExtension.GetTimeStamp()}";
            }
        }
    }
}
