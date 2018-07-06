using Newtonsoft.Json;
using Shared.Util.Extension;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyUserAccount : ProxyBase
    {
        public async Task<double> GetCashAsync(UserAccount account)
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
                    var Uri = CreateUri($"/capitalFlowList?currentPage=1&maxRowsPerPage=10&_ts={TimeExtension.GetTimeStamp().ToString()}");

                    foreach (Cookie token in account.TokenOffical)
                    {
                        cookieJar.Add(Uri, new Cookie(token.Name, token.Value));
                    }

                    var response = await client.GetAsync(Uri);
                    response.EnsureSuccessStatusCode();

                    var jsonString = await response.Content.ReadAsStringAsync();
                    var ret = JsonConvert.DeserializeObject<ClientCapitalFlowList>(jsonString);
                    if (ret != null)
                    {
                        return ret.GetCash();
                    }
                }
            }

            return 0;
        }

        public static async Task<IEnumerable<UserAccount>> LoginAsync(IEnumerable<UserAccount> accounts)
        {
            var ret = new List<UserAccount>();

            if (accounts != null)
            {
                foreach (var account in accounts)
                {
                    var proxyLogin = new ProxyLogin();
                    var para = new VmLogin()
                    {
                        UserName = account.UserName,
                        Password = account.Password,
                        PasswordTran = account.PasswordTran,
                    };
                    account.TokenOffical = await proxyLogin.LoginAsync(para);
                    if (account.HasValue)
                    {
                        ret.Add(account);
                    }
                }
            }

            return ret;
        }
    }
}
