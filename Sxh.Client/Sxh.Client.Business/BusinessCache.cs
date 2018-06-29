using Sxh.Client.Business.Model;

namespace Sxh.Client.Business
{
    public class BusinessCache
    {
        public static User UserLogin { get; set; } = new User();

        private static ClientPortionTransferList _poolTranser;
        public static ClientPortionTransferList PoolTranser
        {
            get { return _poolTranser ?? (_poolTranser = new ClientPortionTransferList()); }
            set { _poolTranser = value; }
        }

        public static UserSettings Settings { get; set; } = new UserSettings();
    }
}
