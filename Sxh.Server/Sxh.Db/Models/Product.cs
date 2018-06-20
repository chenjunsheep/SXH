using System;
using System.Collections.Generic;

namespace Sxh.Db.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public double TotalFunds { get; set; }
        public DateTime ValueDate { get; set; }

        public Project Project { get; set; }
        public ProductPayment ProductPayment { get; set; }
    }
}
