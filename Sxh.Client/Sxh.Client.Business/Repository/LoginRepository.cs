using Sxh.Client.Business.Proxy;
using Sxh.Client.Business.ViewModel;
using System;
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
    }
}
