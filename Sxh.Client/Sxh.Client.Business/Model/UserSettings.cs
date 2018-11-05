using Shared.Util;
using System;
using System.Collections.Generic;

namespace Sxh.Client.Business.Model
{
    public class UserSettings
    {
        private string _searchingKeywordsString;
        public string SearchingKeywordsString
        {
            get { return _searchingKeywordsString; }
            set
            {
                _searchingKeywordsString = TypeParser.GetStringValue(value);

                SearchingKeywords = new List<string>();
                foreach (var keyword in _searchingKeywordsString.Split(new char[] { ';' }))
                {
                    SearchingKeywords.Add(keyword.Trim());
                }
            }
        }

        public List<string> SearchingKeywords { get; private set; } = new List<string>();

        private string _matchingKeywordsString;
        public string MatchingKeywordsString
        {
            get { return _matchingKeywordsString; }
            set
            {
                _matchingKeywordsString = TypeParser.GetStringValue(value);

                MatchingKeywords = new List<string>();
                foreach (var keyword in _matchingKeywordsString.Split(new char[] { ';' }))
                {
                    MatchingKeywords.Add(keyword.Trim());
                }
            }
        }

        public List<string> MatchingKeywords { get; private set; } = new List<string>();

        public double? Yijia { get; set; }
        public double? Rate { get; set; }
        public int? NextPayment { get; set; }
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
            public const string SearchingKeyword = "SearchingKeyword";
            public const string MatchingKeyword = "MatchingKeyword";
            public const string Yijia = "Yijia";
            public const string Rate = "Rate";
            public const string NextPayment = "NextPayment";
            public const string FreqTransfer = "FreqTransfer";
            public const string DelayTransfer = "DelayTransfer";
            public const string TotalPage = "TotalPage";
            public const string AutoAcquire = "AutoAcquire";
        }
    }
}
