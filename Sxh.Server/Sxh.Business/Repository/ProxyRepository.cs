using Sxh.Business.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Shared.Util.Extension;
using Sxh.Business.ViewModel;

namespace Sxh.Business.Repository
{
    public class ProxyRepository : BaseRepository, IProxyRepository
    {
        public async Task<string> LoginAsync(vmLogin para)
        {
            var cookieJar = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieJar,
                UseCookies = true,
                UseDefaultCredentials = false
            };

            var client = CreateHttpClient(handler);
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
            response.EnsureSuccessStatusCode();

            var responseCookies = cookieJar.GetCookies(Uri);
            var ret = string.Empty;
            foreach (Cookie cookie in responseCookies)
            {
                ret += $"{cookie.Name}={cookie.Value};";
            }

            return ret;
        }
    }
}
