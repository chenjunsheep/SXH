using System;
using System.Collections.Generic;

namespace Sxh.Db.Models
{
    public partial class Proxy
    {
        public string Id { get; set; }
        public int TypeId { get; set; }
        public string Token { get; set; }
        public DateTime? LastUpdate { get; set; }

        public ProxyType Type { get; set; }
    }
}
