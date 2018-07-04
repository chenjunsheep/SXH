using Shared.Util;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace Sxh.Client.Business.Model
{
    public class UserAccountCollection : List<UserAccount>
    {
        public void Load()
        {
            LoadFile();
        }

        public void UpdateTokenOffical(string userName, CookieCollection token)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var target = this.FirstOrDefault(u => u.UserName == userName);
                if (target != null)
                {
                    target.TokenOffical = token;
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
