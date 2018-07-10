using Sxh.Client.Util;
using System;
using System.Windows.Forms;

namespace Sxh.Client
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        #region Event

        public event EventHandler OnWindowClosed;

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnWindowClosed != null)
            {
                OnWindowClosed.Invoke(sender, e);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.UiFreeze(false);
            ucSettingBasic.Save();
            Close();
        }

        private void UcSettingProxy_OnProcessBegin(object sender, EventArgs e)
        {
            this.UiFreeze(false);
        }

        private void UcSettingProxy_OnProcessEnd(object sender, EventArgs e)
        {
            this.UiFreeze(true);
        }

        private void UcSettingAccount_OnProcessBegin(object sender, EventArgs e)
        {
            this.UiFreeze(false);
        }

        private void UcSettingAccount_OnProcessEnd(object sender, EventArgs e)
        {
            this.UiFreeze(true);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucSettingProxy.CancelAllTask();
            ucSettingAccount.CancelAllTask();
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            ucSettingBasic.Initialize();

            ucSettingProxy.OnProcessBegin -= UcSettingProxy_OnProcessBegin;
            ucSettingProxy.OnProcessBegin += UcSettingProxy_OnProcessBegin;
            ucSettingProxy.OnProcessEnd -= UcSettingProxy_OnProcessEnd;
            ucSettingProxy.OnProcessEnd += UcSettingProxy_OnProcessEnd;

            ucSettingAccount.OnProcessBegin -= UcSettingAccount_OnProcessBegin;
            ucSettingAccount.OnProcessBegin += UcSettingAccount_OnProcessBegin;
            ucSettingAccount.OnProcessEnd -= UcSettingAccount_OnProcessEnd;
            ucSettingAccount.OnProcessEnd += UcSettingAccount_OnProcessEnd;
        }

        #endregion
    }
}
