using Sxh.Client.Business.Model;
using Sxh.Client.Business.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyUserAccount
    {
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
