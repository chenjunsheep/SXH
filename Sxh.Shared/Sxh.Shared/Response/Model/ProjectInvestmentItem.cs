namespace Sxh.Shared.Response.Model
{
    public class ProjectInvestmentItem
    {
        public int id { get; set; }
        public string memberName { get; set; }
        public int period { get; set; }
        public string periodUnit { get; set; }
        public double projectSchedule { get; set; }
        public int ratePart1 { get; set; }
        public int ratePart2 { get; set; }
        public Amount totalAmount { get; set; }
    }

    public class Amount
    {
        public int fractionPart { get; set; }
        public int intPart { get; set; }
        public string unit { get; set; }
    }
}
