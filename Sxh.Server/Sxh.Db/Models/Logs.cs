using System;
using System.Collections.Generic;

namespace Sxh.Db.Models
{
    public partial class Logs
    {
        public long Id { get; set; }
        public int LogType { get; set; }
        public string Memo { get; set; }
        public DateTime? Date { get; set; }
    }
}
