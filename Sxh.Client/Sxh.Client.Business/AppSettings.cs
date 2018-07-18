namespace Sxh.Client.Business
{
    public class AppSettings
    {
        public AppSetting AppSetting { get; set; }
    }

    public class AppSetting
    {
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

        public string Host = "121.43.71.135:8089";
        public string HostTzb = "www.tzbao.com";
        public string Server = "localhost:898";
        public string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36";
    }
}
