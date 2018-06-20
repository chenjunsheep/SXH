using System;
using System.Collections.Generic;

namespace Sxh.Db.Models
{
    public partial class ProductPayment
    {
        public int ProductId { get; set; }
        public DateTime NextPayment { get; set; }
        public int FreqCurrent { get; set; }
        public int FreqTotal { get; set; }
        public DateTime LastUpdate { get; set; }

        public Product Product { get; set; }
    }
}
