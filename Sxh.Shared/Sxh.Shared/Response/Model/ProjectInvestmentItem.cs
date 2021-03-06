﻿namespace Sxh.Shared.Response.Model
{
    public class ProjectInvestmentItem
    {
        public int id { get; set; }
        public string memberName { get; set; }
        public double period { get; set; }
        public string periodUnit { get; set; }
        public double projectSchedule { get; set; }
        public string ratePart1 { get; set; }
        public string ratePart2 { get; set; }
        public Amount totalAmount { get; set; }
    }
}
