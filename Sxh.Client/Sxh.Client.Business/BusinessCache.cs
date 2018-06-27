using Sxh.Client.Business.Model;
using Sxh.Shared.Response.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sxh.Client.Business
{
    public class BusinessCache
    {
        public static User UserLogin { get; set; } = new User();
        public static PortionTransferList PoolTranser { get; set; } = new PortionTransferList();
    }
}
