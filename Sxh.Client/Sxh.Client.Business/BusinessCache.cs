using Sxh.Client.Business.Model;
using System.Collections.Generic;

namespace Sxh.Client.Business
{
    public class BusinessCache
    {
        public static User UserLogin { get; set; } = new User();

        private static List<User> _accounts;
        public static List<User> Accounts
        {
            get
            {
                if (_accounts == null)
                {
                    _accounts = new List<User>();
                }
                return _accounts;
            }
        }

        private static ClientPortionTransferList _poolTranser;
        public static ClientPortionTransferList PoolTranser
        {
            get { return _poolTranser ?? (_poolTranser = new ClientPortionTransferList()); }
            set { _poolTranser = value; }
        }

        public static UserSettings Settings { get; set; } = new UserSettings();
    }
}
