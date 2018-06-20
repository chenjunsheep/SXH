using System;
using System.Collections.Generic;

namespace Sxh.Db.Models
{
    public partial class Project
    {
        public Project()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public int PayTypeId { get; set; }
        public double Deadline { get; set; }
        public double TotalFunds { get; set; }
        public double Rate { get; set; }

        public PayType PayType { get; set; }
        public StatusType Status { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
