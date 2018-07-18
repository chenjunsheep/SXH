using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Client.Business.Model;
using Sxh.Client.Business;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Util;

namespace Sxh.Client.Controls.Settings
{
    public partial class UcSettingAccountItem : UserControl
    {
        public UcSettingAccountItem()
        {
            InitializeComponent();
        }

        #region Porperty

        const string CASH_INVALID = "--";

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

        public UserAccount Account
        {
            get
            {
                var target = BusinessCache.UserAccounts.FirstOrDefault(p => p.UserName == UserName);
                return target;
            }
        }

        #endregion

        #region Event

        private async void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            await PerformLoginAsync(Account, chkEnabled.Checked);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            sender.CtrlFreeze(false);
            await BindCashAsync(Account);
            sender.CtrlFreeze(true);
        }

        #endregion

        #region Public Method

        public void Initialize(UserAccount account)
        {
            if (account != null)
            {
                txtUserName.Text = account.UserName;
                txtCash.Text = CASH_INVALID;
                Enable(account.HasValue);

                if (IsEnabled)
                {
                    txtCash.Text = $"{account.Cash}";
                }               
            }
        }

        public async Task TryLogin()
        {
            chkEnabled.Checked = true;
            await Task.CompletedTask;
        }

        #endregion

        #region Private Method

        private async Task<bool> PerformLoginAsync(UserAccount account, bool isChecked)
        {
            var enable = false;
            if (isChecked)
            {
                var accountLogin = await ProxyUserAccount.LoginAsync(account);
                await BindCashAsync(accountLogin);
                enable = accountLogin != null;
            }

            Enable(enable);

            return true;
        }

        private void Enable(bool enable)
        {
            chkEnabled.CheckedChanged -= chkEnabled_CheckedChanged;
            chkEnabled.Checked = enable;
            chkEnabled.CheckedChanged += chkEnabled_CheckedChanged;
            BusinessCache.UserAccounts.SetEnable(UserName, enable);
        }

        private async Task BindCashAsync(UserAccount account)
        {
            var strCash = string.Empty;
            if (account == null)
            {
                strCash = CASH_INVALID;
            }
            else
            {
                account.Cash = await BusinessCache.UserAccounts.UpdateCashAsync(account.UserName);
                strCash = $"{account.Cash}";
            }
            txtCash.Text = strCash;
        }

        #endregion
    }
}
