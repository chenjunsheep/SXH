using System;
using System.Collections.Generic;

namespace Sxh.Db.Models
{
    public partial class User
    {
        public string Id { get; set; }
        public string Psw { get; set; }
        public DateTime? Expired { get; set; }
    }
}
