using Sxh.Client.Business.Logs;
using Sxh.Client.Business.Repository;
using Sxh.Client.Business.ViewModel;
using Sxh.Client.Util;
using System;
using System.Windows.Forms;

namespace Sxh.Client
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region Event

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            this.UiFreeze(false);

            var repo = new LoginRepository();
            var taskLogin = repo.LoginAsync(new VmLogin()
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                PasswordTran = txtPasswordTran.Text
            });

            var msg = await taskLogin;
            if (string.IsNullOrEmpty(msg))
            {
                var mainForm = new frmMain();
                mainForm.OnWindowClosed -= MainForm_OnWindowClosed;
                mainForm.Show();
                mainForm.OnWindowClosed += MainForm_OnWindowClosed;

                Hide();
            }
            else
            {
                LogManager.Instance.Message($"login faild: {msg}");
                MessageBox.Show(msg, string.Empty, MessageBoxButtons.OK);
            }

            this.UiFreeze(true);
        }

        private void MainForm_OnWindowClosed(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Private Method

        #endregion
    }
}
