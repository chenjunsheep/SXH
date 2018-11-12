using Sxh.Client.Business.Model;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Repository
{
    public class LoginRepository : BaseRepository
    {
        public async Task<string> LoginAsync(VmLogin para)
        {
            try
            {
                var proxyLogin = new ProxyLogin();
                var tokenOffical = await proxyLogin.LoginAsync(para);
                if (tokenOffical == null || tokenOffical.Count <= 1)
                {
                    return "登陆失败，请检查用户名或密码是否正确";
                }
                BusinessCache.UserLogin.UserName = para.UserName;
                BusinessCache.UserLogin.Password = para.Password;
                BusinessCache.UserLogin.PasswordTran = para.PasswordTran;
                BusinessCache.UserLogin.TokenOffical = tokenOffical;

                await BusinessCache.UserAccounts.UpdateTokenOfficalAsync(para.UserName, tokenOffical);
                BusinessCache.UserProxies.UpdateFromUserAccount(BusinessCache.UserAccounts);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public async Task<KeyValuePair<bool, string>> GetTokenAsync(VmLogin para)
        {
            var proxy = new ProxyServer();
            return await proxy.GetToken(para);
        }

        public async Task<ClientPaymentList> SyncDataProductPaymentAsync(User user)
        {
            var proxy = new ProxyServer();
            return await proxy.SyncDataProductPayment(user);
        }

        public async Task<ClientProjectOverviewList> SyncDataProjectOverviewAsync(User user)
        {
            var proxy = new ProxyServer();
            return await proxy.SyncDataProjectOverview(user);
        }
    }
}
