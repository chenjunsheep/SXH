using Sxh.Client.Business.Model;
using Sxh.Client.Business.ViewModel;
using System.Collections.Generic;
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

        public static async Task<IEnumerable<UserProxy>> LoginAsync(IEnumerable<UserProxy> proxies)
        {
            var ret = new List<UserProxy>();

            if (proxies != null)
            {
                foreach (var proxy in proxies)
                {
                    var isLogin = await LoginAsync(proxy);
                    if (isLogin != null)
                    {
                        ret.Add(proxy);
                    }
                }
            }

            return ret;
        }
    }
}
