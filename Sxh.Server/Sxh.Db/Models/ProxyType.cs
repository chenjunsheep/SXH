using System;
using System.Collections.Generic;

namespace Sxh.Db.Models
{
    public partial class ProxyType
    {
        public ProxyType()
        {
            Proxy = new HashSet<Proxy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Proxy> Proxy { get; set; }
    }
}
