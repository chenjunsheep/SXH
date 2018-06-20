using System;
using System.Collections.Generic;

namespace Sxh.Db.Models
{
    public partial class PayType
    {
        public PayType()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}
