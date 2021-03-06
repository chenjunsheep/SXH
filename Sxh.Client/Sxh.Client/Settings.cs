﻿using Sxh.Client.Util;
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

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucSettingAccount.CancelAllTask();
            ucSettingProxy.CancelAllTask();
            ucSettingTzbProxy.CancelAllTask();
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            ucSettingBasic.Initialize();

            ucSettingAccount.OnProcessBegin -= UcSettingProxy_OnProcessBegin;
            ucSettingAccount.OnProcessBegin += UcSettingProxy_OnProcessBegin;
            ucSettingAccount.OnProcessEnd -= UcSettingProxy_OnProcessEnd;
            ucSettingAccount.OnProcessEnd += UcSettingProxy_OnProcessEnd;

            ucSettingProxy.OnProcessBegin -= UcSettingProxy_OnProcessBegin;
            ucSettingProxy.OnProcessBegin += UcSettingProxy_OnProcessBegin;
            ucSettingProxy.OnProcessEnd -= UcSettingProxy_OnProcessEnd;
            ucSettingProxy.OnProcessEnd += UcSettingProxy_OnProcessEnd;

            ucSettingTzbProxy.OnProcessBegin -= UcSettingProxy_OnProcessBegin;
            ucSettingTzbProxy.OnProcessBegin += UcSettingProxy_OnProcessBegin;
            ucSettingTzbProxy.OnProcessEnd -= UcSettingProxy_OnProcessEnd;
            ucSettingTzbProxy.OnProcessEnd += UcSettingProxy_OnProcessEnd;
        }

        #endregion
    }
}
