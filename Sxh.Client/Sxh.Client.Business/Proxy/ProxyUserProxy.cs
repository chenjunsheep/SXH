using Sxh.Client.Business.Model;
using Sxh.Client.Business.ViewModel;
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

        public static async Task<UserProxy> LoginTzbAsync(UserProxy proxy)
        {
            if (proxy != null)
            {
                var proxyLogin = new ProxyLogin();
                var para = new VmLogin()
                {
                    UserName = proxy.UserName,
                    Password = proxy.Password,
                };
                proxy.TokenOffical = await proxyLogin.LoginTzbAsync(para);
                if (proxy.HasValue)
                {
                    return proxy;
                }
            }

            return null;
        }
    }
}
