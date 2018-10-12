using Newtonsoft.Json;
using Shared.Util.Model;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyServer : ProxyBase
    {
        public async Task<KeyValuePair<bool, string>> GetToken(VmLogin para)
        {
            try
            {
                using (var client = CreateHttpClient(AppSetting.Instance.Server))
                {
                    var uri = CreateUri($"/api/Token/Login", AppSetting.Instance.Server);
                    var jsonData = new StringContent(JsonConvert.SerializeObject(para), Encoding.UTF8, MediaType.JSON);

                    var response = await client.PostAsync(uri, jsonData); var jsonString = await response.Content.ReadAsStringAsync();
                    var msg = JsonConvert.DeserializeObject<string>(jsonString);
                    if (response.IsSuccessStatusCode)
                    {
                        return new KeyValuePair<bool, string>(true, msg);
                    }
                    else
                    {
                        return new KeyValuePair<bool, string>(false, $"[{(int)response.StatusCode} {response.StatusCode}] {msg}");
                    }
                }
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, ex.ToString());
            }
        }

        public async Task<ClientPaymentList> SyncData(User user)
        {
            var ret = new ClientPaymentList();

            try
            {
                using (var client = CreateHttpClient(AppSetting.Instance.Server))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationMode.BEARER, user.TokenServer);

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
            catch (Exception)
            {
                //do nothing
            }

            return ret;
        }
    }
}
