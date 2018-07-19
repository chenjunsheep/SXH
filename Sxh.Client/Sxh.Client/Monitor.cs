using Sxh.Client.Business;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Business.ViewModel;
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
            var user = BusinessCache.UserProxies.GetRandomProxy(0);
            if (user != null)
            {
                if (!user.AvailableInTzb)
                {
                    try
                    {
                        var proxyLogin = new ProxyUserProxy();
                        var cookieTzb = await proxyLogin.LoginTzbAsync(
                            new VmLogin()
                            {
                                UserName = user.UserName,
                                Password = user.Password,
                                PasswordTran = user.PasswordTran,
                            });
                        user.SetTokenTzb(cookieTzb);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (user.AvailableInTzb)
                {
                    try
                    {
                        var ret = await proxy.SearchAsync(user.TokenTzb, para);
                        var aaa = ret;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            
        }
    }
}
