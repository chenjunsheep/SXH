using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Client.Business;
using Sxh.Shared.Tasks;

namespace Sxh.Client.Controls.Settings
{
    public partial class UcSettingProxy : UserControl
    {
        private CancellationManager _cmLoginProxy;
        private CancellationManager CmLoginProxy
        {
            get { return _cmLoginProxy ?? (_cmLoginProxy = new CancellationManager()); }
        }

        public UcSettingProxy()
        {
            InitializeComponent();
        }

        #region Event

        public event EventHandler OnProcessBegin;
        public event EventHandler OnProcessEnd;

        private void UcSettingProxy_Load(object sender, EventArgs e)
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
            LoadProxiesFromCache();
        }

        private void LoadProxiesFromCache()
        {
            var ctrlWidth = Width - 25;
            foreach (var proxy in BusinessCache.UserProxies)
            {
                var ctrl = new UcSettingProxyItem();
                ctrl.Width = ctrlWidth;
                flowProxy.Controls.Add(ctrl);
                ctrl.Initialize(proxy);
            }
        }

        private async Task<bool> LoginBulkAsync(CancellationManager manager)
        {
            try
            {
                var ctrls = new List<UcSettingProxyItem>();
                foreach (Control ctrl in flowProxy.Controls)
                {
                    var ctrlProxy = ctrl as UcSettingProxyItem;
                    if (ctrlProxy != null)
                    {
                        if (!ctrlProxy.IsEnabled)
                        {
                            ctrls.Add(ctrlProxy);
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
                        var ctrlProxy = ctrls[i];
                        await ctrlProxy.TryLogin();

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
