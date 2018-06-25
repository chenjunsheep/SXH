using Sxh.Business.Repository.Interface;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Shared.Util.Extension;

namespace Sxh.Business.Repository
{
    public class BaseRepository : IBaseRepository
    {
        protected HttpClient CreateHttpClient(HttpClientHandler handler = null)
        {
            var client = handler == null ? new HttpClient() : new HttpClient(handler);

            client.DefaultRequestHeaders.Host = AppSetting.Instance.Proxy.TargetHost;
            client.DefaultRequestHeaders.Add("user-agent", AppSetting.Instance.Proxy.UserAgent);
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("zh", 0.8));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("zh-CN", 0.8));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("zh-TW", 0.7));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("zh-HK", 0.5));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US", 0.3));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en", 0.2));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));
            return client;
        }

        protected Uri CreateUri(string path)
        {
            var uri = new Uri($"http://{AppSetting.Instance.Proxy.TargetHost}").AddPath(path);
            return uri;
        }
    }
}
