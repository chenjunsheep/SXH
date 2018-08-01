using Shared.Util.Extension;
using Shared.Util.Model;
using Sxh.Client.Business.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyLogin : ProxyBase
    {
        public async Task<CookieCollection> LoginAsync(VmLogin para)
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
                        new KeyValuePair<string, string>("logonUsername", para.UserName),
                        new KeyValuePair<string, string>("password", para.Password.Md5Encrypt()),
                        new KeyValuePair<string, string>("rememberType", "10080"),
                        new KeyValuePair<string, string>("loginType", "user"),
                        new KeyValuePair<string, string>("verificationCode", "请输入验证码"),
                        new KeyValuePair<string, string>("timeStamp", TimeExtension.GetTimeStamp().ToString()),
                    });

                    var Uri = CreateUri("/auth/loginSubmit");
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
