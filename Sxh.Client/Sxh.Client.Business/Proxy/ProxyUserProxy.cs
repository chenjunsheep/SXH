using Shared.Util.Extension;
using Shared.Util.Model;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyUserProxy : ProxyBase
    {
        public static async Task<UserProxy> LoginAsync(UserProxy proxy)
        {
            if (proxy != null)
            {
                var proxyLogin = new ProxyLogin();
                var para = new VmLogin()
                {
                    UserName = proxy.UserName,
                    Password = proxy.Password,
                };
                proxy.TokenOffical = await proxyLogin.LoginAsync(para);
                if (proxy.HasValue)
                {
                    return proxy;
                }
            }

            return null;
        }

        public async Task<CookieCollection> LoginTzbAsync(VmLogin para)
        {
            var cookieJar = new CookieContainer();
            using (var handler = new HttpClientHandler
            {
                CookieContainer = cookieJar,
                UseCookies = true,
            })
            {
                using (var client = CreateHttpClient(AppSetting.Instance.HostTzb, handler))
                {
                    var formData = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("logonUsername", para.UserName),
                    new KeyValuePair<string, string>("password", para.Password.Md5Encrypt()),
                    new KeyValuePair<string, string>("rememberType", "10080"),
                    new KeyValuePair<string, string>("loginType", "user"),
                    new KeyValuePair<string, string>("verificationCode", string.Empty),
                    new KeyValuePair<string, string>("timeStamp", TimeExtension.GetTimeStamp().ToString()),
                });

                    var Uri = CreateUri("/auth/loginSubmit", AppSetting.Instance.HostTzb, HttpSchema.HTTPS);
                    var response = await client.PostAsync(Uri, formData);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseCookies = cookieJar.GetCookies(Uri);
                        return responseCookies;
                    }
                }
            }
            return new CookieCollection();
        }
    }
}
