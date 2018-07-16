using Shared.Util;
using System;

namespace Sxh.Client.Business.Model
{
    public class UserSettings
    {
        public string Keywords { get; set; }
        public double? Yijia { get; set; }
        public double? Rate { get; set; }
        public int FreqTransfer { get; set; }
        public int DelayTransfer { get; set; }
        public bool AutoAcquire { get; set; }

        private int? _totalPage;
        public int TotalPage
        {
            get
            {
                if (!_totalPage.HasValue)
                {
                    _totalPage = 1;
                }
                return _totalPage.Value;
            }
            set
            {
                _totalPage = Math.Max(TypeParser.GetInt32Value(value, 1), 1);
            }
        }

        public class Namespance
        {
            public const string Keyword = "Keyword";
            public const string Yijia = "Yijia";
            public const string Rate = "Rate";
            public const string FreqTransfer = "FreqTransfer";
            public const string DelayTransfer = "DelayTransfer";
            public const string TotalPage = "TotalPage";
            public const string AutoAcquire = "AutoAcquire";
        }
    }
}
