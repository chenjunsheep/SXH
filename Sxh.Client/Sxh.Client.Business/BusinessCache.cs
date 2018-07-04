using Sxh.Client.Business.Model;

namespace Sxh.Client.Business
{
    public class BusinessCache
    {
        public static User UserLogin { get; set; } = new User();

        private static UserAccountCollection _userAccounts;
        public static UserAccountCollection UserAccounts
        {
            get
            {
                if (_userAccounts == null)
                {
                    _userAccounts = new UserAccountCollection();
                }
                return _userAccounts;
            }
        }

        private static UserProxyCollection _userProxies;
        public static UserProxyCollection UserProxies
        {
            get
            {
                if (_userProxies == null)
                {
                    _userProxies = new UserProxyCollection();
                }
                return _userProxies;
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
