using Shared.Util;
using Sxh.Client.Business;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Business.ViewModel;
using Sxh.Client.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sxh.Client
{
    public partial class Acquisition : Form
    {
        public Acquisition()
        {
            InitializeComponent();
        }

        #region Property

        private ClientPortionTransferItem Project { get; set; }
        private UserAccount Account { get; set; }

        #endregion

        #region Event

        public event EventHandler OnWindowClosed;

        private async void Acquisition_Load(object sender, EventArgs e)
        {
            await Initialize();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            this.UiFreeze(false);

            await SubmitAsync();

            this.UiFreeze(true);

            Close();
        }

        private void Acquisition_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnWindowClosed != null)
            {
                OnWindowClosed.Invoke(sender, e);
            }
        }

        #endregion

        #region Public Method

        public void SetProjectId(int projectId)
        {
            Project = BusinessCache.PoolTranser.GetProjectById(projectId);
            Account = BusinessCache.UserAccounts.GetRandomAccount();
        }

        #endregion

        #region Private Method

        private async Task<bool> Initialize()
        {
            this.UiFreeze(false);

            if (Account != null)
            {
                txtAccount.Text = Account.UserName;
                txtCash.Text = $"{Account.Cash}";
                LoadProjectInformation();
                if (Project != null)
                {
                    if (Project.minTransferingPrice.HasValue)
                    {
                        txtCopy.Text = $"{Project.GetAvailableCopies(Account.Cash)}";
                    }
                    await GetTokensAsync(Account, Project);
                    await GetVerifyCodeAsync(Account);
                }

                this.UiFreeze(true);
                txtVerifyCode.Focus();
            }
            
            return true;
        }

        private void LoadProjectInformation()
        {
            txtProject.Text = Project != null ? Project.GetProjectInformation() : "无效项目信息";
        }

        private async Task<bool> GetTokensAsync(UserAccount account, ClientPortionTransferItem project)
        {
            var proxy = new ProxyAcquisition();
            var ret = await proxy.GetTokenInfoAsync(account, project);
            txtTokenAcquire.Text = ret.TokenAcquire;
            txtToken.Text = ret.TokenKey;
            return true;
        }

        private async Task<bool> GetVerifyCodeAsync(UserAccount account)
        {
            var proxy = new ProxyAcquisition();
            var verifyCode = await proxy.GetVerifyCodeAsync(account);
            using (var ms = new MemoryStream(verifyCode))
            {
                picVerifyCode.Image = Image.FromStream(ms);
            }
            return true;
        }

        private async Task<bool> SubmitAsync()
        {
            if (Project != null && Account != null)
            {
                var para = new VmAcquire()
                {
                    AcquisitionPrice = 96,//TypeParser.GetDoubleValue(Project.minTransferingPrice, 0),
                    Copies = TypeParser.GetInt32Value(txtCopy.Text),
                    ProjectId = Project.projectId,
                    ShowPrice = TypeParser.GetDoubleValue(Project.advicePrice),
                    TockenKey = txtToken.Text,
                    TokenAcquire = txtTokenAcquire.Text,
                    TransactionPassword = Account.PasswordTran,
                    VerificationCode = txtVerifyCode.Text,
                    TokenOffical = Account.TokenOffical,
                };

                var proxy = new ProxyAcquisition();
                return await proxy.SubmitAsync(para);
            }

            return false;
        }

        #endregion
    }
}
