using Sxh.Client.Business;
using Sxh.Client.Business.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sxh.Client
{
    public partial class Monitor : Form
    {
        public Monitor()
        {
            InitializeComponent();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            var para = new ProxyProjectInvestment.Parameter() { PeriodType = Business.Model.PeriodType.Month1 };
            var proxy = new ProxyProjectInvestment();
            var ret = await proxy.SearchAsync(BusinessCache.UserProxies.GetRandomProxy(0).TokenOffical, para);
            var aaa = ret;
        }
    }
}
