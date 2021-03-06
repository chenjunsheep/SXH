﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Client.Business.Model;
using Sxh.Client.Business;
using Sxh.Client.Business.Proxy;

namespace Sxh.Client.Controls.Settings
{
    public partial class UcSettingTzbProxyItem : UserControl
    {
        public UcSettingTzbProxyItem()
        {
            InitializeComponent();
        }

        #region Porperty

        const string PROXY_INVALID = "--";

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
                var target = BusinessCache.UserTzbProxies.FirstOrDefault(p => p.UserName == UserName);
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
                BindWeight(proxy);
                Enable(proxy.Enabled);
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
                var proxyLogin = await ProxyUserProxy.LoginTzbAsync(userProxy);
                BindWeight(proxyLogin);
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
            BusinessCache.UserTzbProxies.SetEnable(UserName, enable);
        }

        private void BindWeight(UserProxy proxy)
        {
            if (proxy != null && proxy.HasValue)
            {
                txtWeight.Text = $"{proxy.Weight}";
            }
            else
            {
                txtWeight.Text = PROXY_INVALID;
            }
        }

        #endregion
    }
}
