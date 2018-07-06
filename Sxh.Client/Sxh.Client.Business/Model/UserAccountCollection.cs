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

        public UserAccount GetRandomAccount()
        {
            var rd = new Random(DateTime.Now.Second);
            var accounts = FindAll(p => p.Enabled).OrderBy(p => rd.Next()).ToList();
            if (accounts != null && accounts.Count > 0)
            {
                var targetProxy = accounts[0];
                return targetProxy;
            }
            return null;
        }

        public async Task<bool> UpdateTokenOfficalAsync(string userName, CookieCollection token)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var target = this.FirstOrDefault(u => u.UserName == userName);
                if (target != null)
                {
                    target.TokenOffical = token;
                    target.Cash = await GetCashAsync(target);
                    target.Enabled = target.Cash > 0;
                }
            }

            return true;
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

        private async Task<double> GetCashAsync(UserAccount account)
        {
            if (account != null)
            {
                var proxy = new ProxyUserAccount();
                return await proxy.GetCashAsync(account);
            }

            return 0;
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
