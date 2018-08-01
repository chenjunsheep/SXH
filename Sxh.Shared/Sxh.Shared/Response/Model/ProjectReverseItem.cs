namespace Sxh.Shared.Response.Model
{
    public class ProjectReverseItem
    {
        public int id { get; set; }
        public double amount { get; set; }
        public double period { get; set; }
        public double rate { get; set; }
        public RepaymentType repaymentStrategy { get; set; }
        public Status status { get; set; }

        public class RepaymentType
        {
            public string name { get; set; }
            public string periodUnit { get; set; }

            public class Namespace
            {
                public const string DAY = "DAY_INTEREST_EXPIRE";
                public const string MONTH = "MONTH_CAPITAL_INTEREST_EXPIRE";
            }
        }

        public class Status
        {
            public string name { get; set; }

            public class Namespace
            {
                public const string SUCCESS = "SUCCESS";
                public const string WAIT = "WAIT";
            }
        }
    }
}
