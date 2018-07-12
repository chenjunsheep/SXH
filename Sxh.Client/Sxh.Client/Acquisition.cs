using Shared.Util;
using Sxh.Client.Business;
using Sxh.Client.Business.Logs;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Business.ViewModel;
using Sxh.Client.Util;
using Sxh.Shared.Response;
using System;
using System.Drawing;
using System.IO;
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
            Initialize();
            await BindValuesAsync();
            
            if (BusinessCache.Settings.AutoAcquire)
            {
                btnSubmit.PerformClick();
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            await SubmitClickedAsync();
        }

        private async void txtVerifyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                await SubmitClickedAsync();
        }

        private async void txtCopy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                await SubmitClickedAsync();
        }

        private void Acquisition_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnWindowClosed != null)
            {
                OnWindowClosed.Invoke(sender, e);
            }
        }

        private async void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UiFreeze(false);
            Account = BusinessCache.UserAccounts.GetAccount($"{cbAccount.SelectedValue}");
            await BindValuesAsync();
            this.UiFreeze(true);
        }

        #endregion

        #region Public Method

        public bool SetProjectId(int projectId)
        {
            Project = BusinessCache.PoolTranser.GetProjectById(projectId);
            if (Project != null && Project.minTransferingPrice.HasValue)
            {
                Account = BusinessCache.UserAccounts.GetRandomAccount(Project.minTransferingPrice.Value * 100);
                if (Account != null)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Private Method

        private async Task<bool> BindValuesAsync()
        {
            this.UiFreeze(false);

            if (Account != null)
            {
                Account.Cash = await BusinessCache.UserAccounts.UpdateCashAsync(Account.UserName);
                txtCash.Text = $"{Account.Cash}";
                LoadProjectInformation();
                if (Project != null)
                {
                    txtCopy.Text = $"{Project.GetAvailableCopies(Account.Cash)}";
                    await GetTokensAsync(Account, Project);
                    await GetVerifyCodeAsync(Account);
                }

                this.UiFreeze(true);
                txtVerifyCode.Focus();
            }
            
            return true;
        }

        private void Initialize()
        {
            cbAccount.ValueMember = "UserName";
            cbAccount.DisplayMember = "UserName";
            cbAccount.DataSource = BusinessCache.UserAccounts.FindAll(u => u.Enabled && u.HasValue);
            cbAccount.SelectedValue = Account.UserName;
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
            if (verifyCode.IsSuccess)
            {
                var code = verifyCode.Data as byte[];
                if (code != null)
                {
                    using (var ms = new MemoryStream(code))
                    {
                        picVerifyCode.Image = Image.FromStream(ms);
                    }

                    txtVerifyCode.Text = await DecodeVerifyCode(code);

                    return true;
                }
            }

            return false;
        }

        private async Task<string> DecodeVerifyCode(byte[] code)
        {
            if (BusinessCache.Settings.AutoAcquire)
            {
                var proxy = new ProxyDecoder();
                return await proxy.DecodeAsync(code);
            }
            return string.Empty;
        }

        private async Task<SxhResult> SubmitAsync()
        {
            if (Project != null && Account != null)
            {
                var para = new VmAcquire()
                {
                    AcquisitionPrice = TypeParser.GetDoubleValue(Project.minTransferingPrice, 0),
                    Copies = TypeParser.GetInt32Value(txtCopy.Text),
                    ProjectId = Project.projectId,
                    ProjectName = Project.projectTitle,
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

            return new SxhResult(false, $"invalid project or account");
        }

        private async Task SubmitClickedAsync()
        {
            this.UiFreeze(false);

            var ret = await SubmitAsync();
            await BusinessCache.UserAccounts.UpdateCashAsync(Account.UserName);

            this.UiFreeze(true);
            Close();

            //if (ret.IsSuccess)
            //{
            //    Close();
            //}
            //else
            //{
            //    await GetVerifyCodeAsync(Account);
            //    Account = BusinessCache.UserAccounts.GetAccount(Account.UserName);
            //    if (Account != null) txtAccount.Text = $"{Account.Cash}";
            //}

            if (!string.IsNullOrEmpty(ret.Message))
                LogManager.Instance.Message(ret.Message);
        }

        #endregion
    }
}
