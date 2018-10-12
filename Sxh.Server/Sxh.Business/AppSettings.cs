namespace Sxh.Business
{
    public class AppSettings
    {
        public AppSetting AppSetting { get; set; }
    }

    public class AppSetting
    {
        public string SecretKey { get; set; }
        public double TokenExpiredHour { get; set; }
        public Schedule Schedules { get; set; }
        public ProxyInfo Proxy { get; set; }

        private DbConnect _dbConnect;
        public DbConnect DbConnection
        {
            get { return _dbConnect ?? (_dbConnect = new DbConnect()); }
            private set { _dbConnect = value; }
        }

        private static AppSetting _instance;
        public static AppSetting Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppSetting();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public class Schedule
        {
            public string TargetServer { get; set; }

            public InnerModel Heartbeat { get; set; }

            public InnerModel NextPayment { get; set; }

            public class InnerModel
            {
                public int Frequency { get; set; }
            }
        }

        public class ProxyInfo
        {
            public string TargetHost { get; set; }
            public string UserAgent { get; set; }
        }

        public class DbConnect
        {
            public string Sxh { get; private set; }

            public void SetDbConnectStringSxh(string conn)
            {
                Sxh = conn;
            }
        }
    }
}
