using Shared.Util;
using Sxh.Client.Business;
using Sxh.Client.Business.Logs;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Business.Repository;
using Sxh.Client.Business.ViewModel;
using Sxh.Client.Util;
using System;
using System.IO;
using System.Linq;
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

        #region Event

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            Text = "登陆中，请稍后...";

            this.UiFreeze(false);

            var repo = new LoginRepository();
            var para = new VmLogin()
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                PasswordTran = txtPasswordTran.Text
            };

            var msg = await repo.LoginAsync(para);
            if (string.IsNullOrEmpty(msg))
            {
                Text = "服务器验证...";
                var retToken = await repo.GetTokenAsync(para);
                if (retToken.Key)
                {
                    BusinessCache.UserLogin.TokenServer = retToken.Value;
                    Text = "同步服务器数据（项目概要）...";
                    BusinessCache.ProjectOverviewList = await repo.SyncDataProjectOverviewAsync(BusinessCache.UserLogin);
                    Text = "同步服务器数据（付息计划）...";
                    BusinessCache.ProjectPayments = await repo.SyncDataProductPaymentAsync(BusinessCache.UserLogin);
                    Text = "初始化...";

                    var mainForm = new frmMain();
                    mainForm.OnWindowClosed -= MainForm_OnWindowClosed;
                    mainForm.Show();
                    mainForm.OnWindowClosed += MainForm_OnWindowClosed;

                    Hide();
                }
                else
                {
                    MessageBox.Show(retToken.Value, string.Empty, MessageBoxButtons.OK);
                }
            }
            else
            {
                Text = "登陆失败";
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

        private void Initialize()
        {
            BusinessCache.UserAccounts.Load();
            BusinessCache.UserProxies.Load(UserProxyCollection.Namespace.FileNameProxySxh);
            BusinessCache.UserTzbProxies.Load(UserProxyCollection.Namespace.FileNameProxyTzb);

            var def = BusinessCache.UserAccounts.FirstOrDefault();
            if (def != null)
            {
                txtUserName.Text = def.UserName;
                txtPassword.Text = def.Password;
                txtPasswordTran.Text = def.PasswordTran;
            }
        }

        //private async Task SyncServerDataAsync()
        //{
        //    var proxy = new ProxyServer();
        //    var dataPayments = await proxy.SyncData();
        //    BusinessCache.ProjectPayments = dataPayments;
        //}

        #endregion
    }
}
