using System;

namespace Sxh.Shared.Response.Model
{
    public class PaymentItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NextPayment { get; set; }
        public string Freq { get; set; }
        public double Fund { get; set; }
        public double FundTotal { get; set; }
        public double Rate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
