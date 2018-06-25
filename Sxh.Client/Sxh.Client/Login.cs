using Sxh.Client.Business.Repository;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            UiRefresh(false);

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
                MessageBox.Show(msg, string.Empty, MessageBoxButtons.OK);
            }

            UiRefresh(true);
        }

        private void MainForm_OnWindowClosed(object sender, EventArgs e)
        {
            Close();
        }

        #region Private Method

        private void UiRefresh(bool enable)
        {
            foreach (Control ctr in Controls)
            {
                ctr.Enabled = enable;
            }
        }

        #endregion
    }
}
