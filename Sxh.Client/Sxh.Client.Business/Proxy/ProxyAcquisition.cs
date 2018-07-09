using Shared.Util.Extension;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.ViewModel;
using Sxh.Shared.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyAcquisition : ProxyBase
    {
        #region Property

        //private User Account { get; set; }
        //private ClientPortionTransferItem Project { get; set; }
        //private TokenAcquisition TokenInfo { get; set; }

        #endregion

        #region Constructor

        //public ProxyAcquisition()
        //{
        //    Account = account;
        //    Project = project;
        //}

        #endregion

        #region Public Method

        public async Task<TokenAcquisition> GetTokenInfoAsync(UserAccount account, ClientPortionTransferItem project)
        {
            var tokenInfo = new TokenAcquisition();

            if (account != null && account.HasValue && project != null)
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
                        var Uri = CreateUri($"/CommissionedAcquisition?projectId={project.projectId}&currentPrice={project.minTransferingPrice}");

                        foreach (Cookie token in account.TokenOffical)
                        {
                            cookieJar.Add(Uri, new Cookie(token.Name, token.Value));
                        }

                        var response = await client.GetAsync(Uri);
                        if (response.IsSuccessStatusCode)
                        {
                            var html = await response.Content.ReadAsStringAsync();
                            RetrieveToken(html, tokenInfo);
                        }
                    }
                }
            }

            return tokenInfo;
        }

        public async Task<SxhResult> GetVerifyCodeAsync(UserAccount account)
        {
            if (account != null && account.HasValue)
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
                        var Uri = CreateUri($"/sxhig/generateCaptchaCode?t={TimeExtension.GetTimeStamp().ToString()}");

                        foreach (Cookie token in account.TokenOffical)
                        {
                            cookieJar.Add(Uri, new Cookie(token.Name, token.Value));
                        }

                        var response = await client.GetAsync(Uri);
                        if (response.IsSuccessStatusCode)
                        {
                            var bytes = await response.Content.ReadAsByteArrayAsync();
                            return new SxhResult(true, bytes);
                        }
                        else
                        {
                            return new SxhResult(false, response.StatusCode);
                        }
                    }
                }
            }

            return new SxhResult(false);
        }

        public async Task<SxhResult> SubmitAsync(VmAcquire para)
        {
            if (para != null)
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
                        client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                        client.DefaultRequestHeaders.Add("Accept", "*/*");
                        client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                        client.DefaultRequestHeaders.Referrer = CreateUri($"CommissionedAcquisition?projectId={para.ProjectId}&currentPrice={para.ShowPrice}");

                        var formData = new FormUrlEncodedContent(new[] {
                            new KeyValuePair<string, string>("acquisitionPrice", $"{para.AcquisitionPrice}"),
                            new KeyValuePair<string, string>("copies", $"{ para.Copies}"),
                            new KeyValuePair<string, string>("checkbox1", "on"),
                            new KeyValuePair<string, string>("projectId", $"{para.ProjectId}"),
                            new KeyValuePair<string, string>("TOKEN_ACQUIRE", para.TokenAcquire),
                            new KeyValuePair<string, string>("showPrice", $"{para.ShowPrice}"),
                            new KeyValuePair<string, string>("transactionPassword", para.TransactionPassword.Md5Encrypt()),
                            new KeyValuePair<string, string>("verificationCode", para.VerificationCode),
                            new KeyValuePair<string, string>("tockenKey", para.TockenKey),
                        });

                        var uri = CreateUri("/project/acquisitionSubmit");

                        foreach (Cookie token in para.TokenOffical)
                        {
                            cookieJar.Add(uri, new Cookie(token.Name, token.Value));
                        }

                        var response = await client.PostAsync(uri, formData);
                        if (response.IsSuccessStatusCode)
                        {
                            await response.Content.ReadAsStringAsync();
                            return new SxhResult(true, $"{para.Copies}份 {para.ProjectName}已成功提交");
                        }
                        else
                        {
                            return new SxhResult(false, response.StatusCode);
                        }

                        
                    }
                }
            }

            return new SxhResult(false);
        }

        #endregion

        #region Private Method

        private void RetrieveToken(string html, TokenAcquisition tokenInfo)
        {
            var tokenAcquire = Regex.Match(html, "TOKEN_ACQUIRE.*?(/>)", RegexOptions.IgnoreCase);
            if (tokenAcquire.Success)
            {
                var queryToken = Regex.Match(tokenAcquire.Value, "value=(\"|').*(\"|')", RegexOptions.IgnoreCase);
                if (queryToken.Success)
                {
                    tokenInfo.TokenAcquire = queryToken.Value.Replace("value=", string.Empty).Replace("\"", string.Empty).Replace("'", string.Empty).Trim();
                }
            }

            var tokenKey = Regex.Match(html, "tockenKey.*?(/>)", RegexOptions.IgnoreCase);
            if (tokenKey.Success)
            {
                var queryToken = Regex.Match(tokenKey.Value, "value=(\"|').*(\"|')", RegexOptions.IgnoreCase);
                if (queryToken.Success)
                {
                    tokenInfo.TokenKey = queryToken.Value.Replace("value=", string.Empty).Replace("\"", string.Empty).Replace("'", string.Empty).Trim();
                }
            }
        }

        #endregion

        #region Class

        public class TokenAcquisition
        {
            public string TokenAcquire { get; set; }
            public string TokenKey { get; set; }

            public bool HasValue
            {
                get { return !string.IsNullOrEmpty(TokenAcquire) && !string.IsNullOrEmpty(TokenKey); }
            }
        }

        #endregion
    }
}
