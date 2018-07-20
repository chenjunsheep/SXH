using Shared.Util;
using Sxh.Client.Business.Proxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace Sxh.Client.Business.Model
{
    public class UserAccountCollection : List<UserAccount>
    {
        public void Load()
        {
            LoadFromFile();
        }

        public UserAccount GetAccount(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var target = this.FirstOrDefault(u => u.UserName == userName);
                if (target != null)
                {
                    return target;
                }
            }

            return null;
        }

        public UserAccount GetRandomAccount(double minCash)
        {
            var rd = new Random(DateTime.Now.Second);
            var accounts = FindAll(p => p.Enabled && p.Cash >= minCash).OrderBy(p => rd.Next()).ToList();
            if (accounts != null && accounts.Count > 0)
            {
                var targetProxy = accounts[0];
                return targetProxy;
            }
            return null;
        }

        public UserAccount SetEnable(string userName, bool enable)
        {
            var target = this.FirstOrDefault(u => u.UserName == userName);
            if (target != null)
            {
                target.Enabled = enable;
                return target;
            }
            return null;
        }

        public async Task<bool> UpdateTokenOfficalAsync(string userName, CookieCollection token)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var target = GetAccount(userName);
                if (target != null)
                {
                    target.TokenOffical = token;
                    target.Enabled = true;

                    await UpdateCashAsync(userName);
                }
            }

            return true;
        }

        public async Task<double> UpdateCashAsync(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var target = GetAccount(userName);
                if (target != null)
                {
                    var proxy = new ProxyUserAccount();
                    var cash = await proxy.GetCashAsync(target);
                    target.Cash = cash;

                    return cash;
                }
            }

            return 0;
        }

        public void UpdateFromUserProxy(IEnumerable<UserProxy> proxies)
        {
            if (proxies != null)
            {
                foreach (var proxy in proxies)
                {
                    var target = this.FirstOrDefault(u => u.UserName == proxy.UserName);
                    if (target != null && proxy.HasValue)
                    {
                        target.TokenOffical = proxy.TokenOffical;
                    }
                }
            }
        }

        private void LoadFromFile()
        {
            Clear();

            if (File.Exists(Namespace.FileName))
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(Namespace.FileName);

                var selectSingleNode = xmlDoc.SelectSingleNode(Namespace.Root);
                if (selectSingleNode != null)
                {
                    foreach (XmlElement childNode in selectSingleNode.ChildNodes)
                    {
                        var account = new UserAccount();
                        account.UserName = TypeParser.GetStringValue(childNode.GetAttribute(Namespace.Id));
                        account.Password = TypeParser.GetStringValue(childNode.GetAttribute(Namespace.Password));
                        account.PasswordTran = TypeParser.GetStringValue(childNode.GetAttribute(Namespace.Tranword));
                        Add(account);
                    }
                }
            }
        }

        public class Namespace
        {
            public const string FileName = "account.xml";
            public const string Root = "root";
            public const string Id = "id";
            public const string Password = "psw";
            public const string Tranword = "tsw";
        }
    }
}
