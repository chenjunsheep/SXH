using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Shared.Util.Extension;
using Shared.Util.Model;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyBase
    {
        protected HttpClient CreateHttpClient(HttpClientHandler handler = null)
        {
            return CreateHttpClient(AppSetting.Instance.Host, handler);
        }

        protected HttpClient CreateHttpClient(string domain, HttpClientHandler handler = null)
        {
            var client = handler == null ? new HttpClient() : new HttpClient(handler);

            client.DefaultRequestHeaders.Host = domain;
            client.DefaultRequestHeaders.Add("user-agent", AppSetting.Instance.UserAgent);
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

        public static Uri CreateUri(string path)
        {
            return CreateUri(path, AppSetting.Instance.Host);
        }

        public static Uri CreateUri(string path, string domain)
        {
            var uri = CreateUri(path, domain, HttpSchema.HTTP);
            return uri;
        }

        public static Uri CreateUri(string path, string domain, string httpSchema)
        {
            var uri = new Uri($"{httpSchema}{domain}").AddPath(path);
            return uri;
        }
    }
}
