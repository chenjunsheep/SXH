using Sxh.Client.Business;
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

        #endregion

        #region Private Method

        private void Initialize()
        {
            ucSettingBasic.Initialize();
        }

        #endregion

        
    }
}
