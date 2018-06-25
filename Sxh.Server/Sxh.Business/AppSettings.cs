namespace Sxh.Business
{
    public class AppSettings
    {
        public AppSetting AppSetting { get; set; }
    }

    public class AppSetting
    {
        public Schedule Schedules { get; set; }
        public ProxyInfo Proxy { get; set; }

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
            public Heartbeat Heartbeats { get; set; }

            public class Heartbeat
            {
                public string TargetServer { get; set; }
                public int Frequency { get; set; }
            }
        }

        public class ProxyInfo
        {
            public string TargetHost { get; set; }
            public string UserAgent { get; set; }
        }
    }
}
