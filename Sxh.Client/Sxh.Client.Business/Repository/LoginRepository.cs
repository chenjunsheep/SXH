using Sxh.Client.Business.Proxy;
using Sxh.Client.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if (string.IsNullOrEmpty(tokenOffical))
                {
                    return "登陆失败，无法获取token";
                }
                BusinessCache.UserLogin.UserName = para.UserName;
                BusinessCache.UserLogin.Password = para.Password;
                BusinessCache.UserLogin.PasswordTran = para.PasswordTran;
                BusinessCache.UserLogin.TokenOffical = tokenOffical;
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
