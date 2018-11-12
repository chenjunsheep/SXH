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

        private static UserProxyCollection _userTzbProxies;
        public static UserProxyCollection UserTzbProxies
        {
            get { return _userTzbProxies ?? (_userTzbProxies = new UserProxyCollection()); }
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

        private static ClientProjectOverviewList _projectOverviewList;
        public static ClientProjectOverviewList ProjectOverviewList
        {
            get { return _projectOverviewList ?? (_projectOverviewList = new ClientProjectOverviewList()); }
            set { _projectOverviewList = value; }
        }

        private static MonitorInfo _monitorInfo;
        public static MonitorInfo MonitorInfo
        {
            get { return _monitorInfo ?? (_monitorInfo = new MonitorInfo()); }
            set { _monitorInfo = value; }
        }
    }
}
