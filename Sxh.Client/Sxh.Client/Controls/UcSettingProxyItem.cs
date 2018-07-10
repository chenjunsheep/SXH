using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Client.Business;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.Proxy;

namespace Sxh.Client.Controls
{
    public partial class UcSettingProxyItem : UserControl
    {
        public UcSettingProxyItem()
        {
            InitializeComponent();
        }

        #region Porperty

        public string UserName
        {
            get
            {
                return txtUserName.Text;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return chkEnabled.Checked;
            }
        }

        public UserProxy Proxy
        {
            get
            {
                var target = BusinessCache.UserProxies.FirstOrDefault(p => p.UserName == UserName);
                return target;
            }
        }

        #endregion

        #region Event

        private async void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            await PerformLoginAsync(Proxy, chkEnabled.Checked);
        }

        #endregion

        #region Public Method

        public void Initialize(UserProxy proxy)
        {
            if (proxy != null)
            {
                txtUserName.Text = proxy.UserName;
                BindToken(proxy);
                Enable(proxy.HasValue);
            }
        }

        public async Task TryLogin()
        {
            chkEnabled.Checked = true;
            await Task.CompletedTask;
        }

        #endregion

        #region Private Method

        private async Task<bool> PerformLoginAsync(UserProxy userProxy, bool isChecked)
        {
            var enable = false;
            if (isChecked)
            {
                var proxyLogin = await ProxyUserProxy.LoginAsync(userProxy);
                BindToken(proxyLogin);
                enable = proxyLogin != null;
            }

            Enable(enable);

            return true;
        }

        private void Enable(bool enable)
        {
            chkEnabled.CheckedChanged -= chkEnabled_CheckedChanged;
            chkEnabled.Checked = enable;
            chkEnabled.CheckedChanged += chkEnabled_CheckedChanged;
            BusinessCache.UserProxies.SetEnable(UserName, enable);
        }

        private void BindToken(UserProxy proxy)
        {
            var strToken = string.Empty;
            if (proxy == null)
            {
                strToken = "登陆失败";
            }
            else
            {
                strToken = proxy.DisplayTokenOffical;
            }
            txtToken.Text = strToken;
        }

        #endregion
    }
}
