namespace Sxh.Client.Business.Model
{
    public class UserSettings
    {
        public string Keywords { get; set; }
        public double? Yijia { get; set; }
        public double? Rate { get; set; }
        public int FreqTransfer { get; set; }
        public int DelayTransfer { get; set; }

        public class Namespance
        {
            public const string Keyword = "Keyword";
            public const string Yijia = "Yijia";
            public const string Rate = "Rate";
            public const string FreqTransfer = "FreqTransfer";
            public const string DelayTransfer = "DelayTransfer";
        }
    }
}
