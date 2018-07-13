using Sxh.Client.Business.Model;

namespace Sxh.Client.Business
{
    public class BusinessCache
    {
        public static User UserLogin { get; set; } = new User();

        private static UserAccountCollection _userAccounts;
        public static UserAccountCollection UserAccounts
        {
            get { return _userAccounts ?? (_userAccounts = new UserAccountCollection()); }
        }

        private static UserProxyCollection _userProxies;
        public static UserProxyCollection UserProxies
        {
            get { return _userProxies ?? (_userProxies = new UserProxyCollection()); }
        }

        private static ClientPortionTransferList _poolTranser;
        public static ClientPortionTransferList PoolTranser
        {
            get { return _poolTranser ?? (_poolTranser = new ClientPortionTransferList()); }
            set { _poolTranser = value; }
        }

        public static UserSettings Settings { get; set; } = new UserSettings();

        private static ClientPaymentList _projectPayments;
        public static ClientPaymentList ProjectPayments
        {
            get { return _projectPayments ?? (_projectPayments = new ClientPaymentList()); }
            set { _projectPayments = value; }
        }
    }
}
