using Shared.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Sxh.Client.Business.Model
{
    public class UserProxyCollection : List<UserProxy>
    {
        public void Load()
        {
            LoadFile();
        }

        public UserProxy GetRandomProxy()
        {
            var rd = new Random(DateTime.Now.Second);
            var proxies = FindAll(p => p.Enabled).OrderBy(p => rd.Next()).OrderBy(p => p.Weight).ToList();
            if (proxies != null && proxies.Count > 0)
            {
                var targetProxy = proxies[0];
                SetWeight(targetProxy.UserName);
                return targetProxy;
            }
            return null;
        }

        public UserProxy SetEnable(string userName, bool enable)
        {
            var target = this.FirstOrDefault(u => u.UserName == userName);
            if (target != null)
            {
                target.Enabled = enable;
                return target;
            }
            return null;
        }

        public UserProxy SetWeight(string userName)
        {
            var target = this.FirstOrDefault(u => u.UserName == userName);
            if (target != null)
            {
                target.Weight++;
                return target;
            }
            return null;
        }

        public void UpdateFromUserAccount(IEnumerable<UserAccount> accounts)
        {
            if (accounts != null)
            {
                foreach (var account in accounts)
                {
                    var target = this.FirstOrDefault(u => u.UserName == account.UserName);
                    if (target != null && account.HasValue)
                    {
                        target.TokenOffical = account.TokenOffical;
                    }
                }
            }
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

        private void LoadFile()
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
                        var proxy = new UserProxy();
                        proxy.UserName = TypeParser.GetStringValue(childNode.GetAttribute(Namespace.Id));
                        proxy.Password = TypeParser.GetStringValue(childNode.GetAttribute(Namespace.Password));
                        Add(proxy);
                    }
                }
            }
        }

        public class Namespace
        {
            public const string FileName = "proxy.xml";
            public const string Root = "root";
            public const string Id = "id";
            public const string Password = "psw";
        }
    }
}
