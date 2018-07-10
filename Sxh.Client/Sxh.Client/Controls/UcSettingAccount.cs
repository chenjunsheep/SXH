using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Shared.Tasks;
using Sxh.Client.Business;

namespace Sxh.Client.Controls
{
    public partial class UcSettingAccount : UserControl
    {
        private CancellationManager _cmLoginProxy;
        private CancellationManager CmLoginProxy
        {
            get { return _cmLoginProxy ?? (_cmLoginProxy = new CancellationManager()); }
        }

        public UcSettingAccount()
        {
            InitializeComponent();
        }

        #region Event

        public event EventHandler OnProcessBegin;
        public event EventHandler OnProcessEnd;

        private void UcSettingAccount_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void btnLoginBulk_Click(object sender, EventArgs e)
        {
            if (OnProcessBegin != null)
            {
                OnProcessBegin.Invoke(sender, e);
            }

            CmLoginProxy.Activate();
            await LoginBulkAsync(CmLoginProxy);

            if (OnProcessEnd != null)
            {
                OnProcessEnd.Invoke(sender, e);
            }
        }

        #endregion

        #region Public Method

        public void CancelAllTask()
        {
            CmLoginProxy.Cancel();
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            LoadAccountsFromCache();
        }

        private void LoadAccountsFromCache()
        {
            var ctrlWidth = Width - 25;
            foreach (var account in BusinessCache.UserAccounts)
            {
                var ctrl = new UcSettingAccountItem();
                ctrl.Width = ctrlWidth;
                flowAccount.Controls.Add(ctrl);
                ctrl.Initialize(account);
            }
        }

        private async Task<bool> LoginBulkAsync(CancellationManager manager)
        {
            try
            {
                var ctrls = new List<UcSettingAccountItem>();
                foreach (Control ctrl in flowAccount.Controls)
                {
                    var ctrlAccount = ctrl as UcSettingAccountItem;
                    if (ctrlAccount != null)
                    {
                        if (!ctrlAccount.IsEnabled)
                        {
                            ctrls.Add(ctrlAccount);
                        }
                    }
                }

                var delayMax = chkLoginProtect.Checked ? 30 : 0;
                var delayMin = chkLoginProtect.Checked ? 5 : 0;
                var rd = new Random(DateTime.Now.Second);
                ctrls = ctrls.OrderBy(c => rd.Next()).ToList();
                for (var i = 0; i < ctrls.Count; i++)
                {
                    if (!manager.Token.IsCancellationRequested)
                    {
                        var ctrlAccount = ctrls[i];
                        await ctrlAccount.TryLogin();

                        if (i == ctrls.Count - 1) { break; }

                        await Task.Delay(rd.Next(delayMin, delayMax) * 1000);
                    }
                    else
                    {
                        manager.Token.ThrowIfCancellationRequested();
                    }
                }
            }
            catch (Exception)
            {
                //do nothing
            }
            finally
            {
                manager.Dispose();
            }

            return true;
        }

        #endregion
    }
}
