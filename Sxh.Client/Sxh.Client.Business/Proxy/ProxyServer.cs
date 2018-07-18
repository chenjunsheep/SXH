using Newtonsoft.Json;
using Shared.Util.Model;
using Sxh.Client.Business.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyServer : ProxyBase
    {
        public async Task<ClientPaymentList> SyncData()
        {
            var ret = new ClientPaymentList();

            try
            {
                var cookieJar = new CookieContainer();
                using (var handler = new HttpClientHandler
                {
                    CookieContainer = cookieJar,
                    UseCookies = true,
                })
                {
                    using (var client = CreateHttpClient(AppSetting.Instance.Server, handler))
                    {
                        var content = new StringContent("pagersettings", Encoding.UTF8, MediaType.JSON);
                        var Uri = CreateUri("/api/ProductPayments/GetProductPayment", AppSetting.Instance.Server);

                        var response = await client.PostAsync(Uri, content);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            ret = JsonConvert.DeserializeObject<ClientPaymentList>(jsonString);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //do nothing
            }

            return ret;
        }
    }
}
