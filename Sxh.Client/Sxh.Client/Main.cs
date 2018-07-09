using Sxh.Client.Business;
using Sxh.Client.Business.Logs;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Util;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Util.Extension;
using Sxh.Shared.Tasks;

namespace Sxh.Client
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region Private Member

        private CancellationManager _cmSearching;
        private CancellationManager CmSearching
        {
            get { return _cmSearching ?? (_cmSearching = new CancellationManager()); }
        }

        #endregion

        #region Event

        public event EventHandler OnWindowClosed;

        private void frmMain_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnWindowClosed != null)
            {
                OnWindowClosed.Invoke(sender, e);
            }
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            splitMain.Panel2Collapsed = !splitMain.Panel2Collapsed;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            BusinessCache.PoolTranser.UnLock();
            ButtonGroupFreeze(true);
            CmSearching.Activate();
            PerformSearching(CmSearching);

            while (!CmSearching.IsCancelled)
            {
                await Task.Delay(1000);
            }

            ButtonGroupFreeze(false);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            LogManager.Instance.Message("cancelling, please wait...");
            sender.CtrlFreeze(false);
            CmSearching.Cancel();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var formSettings = new Settings();
            formSettings.OnWindowClosed -= FormSettings_OnWindowClosed;
            formSettings.OnWindowClosed += FormSettings_OnWindowClosed;
            formSettings.ShowDialog();
        }

        private void FormSettings_OnWindowClosed(object sender, EventArgs e)
        {
            lblOverview.Text = GenerateOverviewInfo();
        }

        private void UcPoolTranser_OnTargeted(object sender, EventArgs e)
        {
            BusinessCache.PoolTranser.Lock();

            if (notify.Visible)
            {
                var msg = ucPoolTranser.GetTargetedProjectInfo();
                if (!string.IsNullOrEmpty(msg))
                {
                    notify.ShowBalloonTip(2000, "Message", msg.SubLeftString(10), ToolTipIcon.None);
                }
            }

            CmSearching.Cancel();
            ButtonGroupFreeze(false);
            ucPoolTranser.PerformTargeted();
        }
        
        private void UcPoolTranser_OnDeTargeted(object sender, EventArgs e)
        {

        }

        private void notify_DoubleClick(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            notify.Visible = false;
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notify.Visible = true;
            }
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            BusinessCache.Settings.TryRetriveFromConfig();

            if (BusinessCache.UserLogin.HasValue)
            {
                this.UiFreeze(true);
            }
            else
            {
                this.UiFreeze(false);
            }

            splitMain.Panel2Collapsed = true;
            btnStop.Enabled = false;

            Text = $"欢迎你，{BusinessCache.UserLogin.UserName}";
            lblOverview.Text = GenerateOverviewInfo();

            ucPoolTranser.OnTargeted -= UcPoolTranser_OnTargeted;
            ucPoolTranser.OnTargeted += UcPoolTranser_OnTargeted;
            ucPoolTranser.OnDeTargeted -= UcPoolTranser_OnDeTargeted;
            ucPoolTranser.OnDeTargeted += UcPoolTranser_OnDeTargeted;
        }

        private void ButtonGroupFreeze(bool inprocess)
        {
            btnStart.Enabled = !inprocess;
            btnSettings.Enabled = !inprocess;
            btnStop.Enabled = inprocess;
        }

        private void PerformSearching(CancellationManager manager)
        {
            Task.Factory.StartNew(() => {
                var settingInfo = BusinessCache.Settings;
                var rd = new Random();
                var proxySearch = new ProxySearch();
                try
                {
                    while (!manager.Token.IsCancellationRequested)
                    {
                        var delay = (rd.Next(0, settingInfo.DelayTransfer));

                        var searchProxy = BusinessCache.UserProxies.GetRandomProxy();
                        if (searchProxy != null)
                        {
                            try
                            {
                                BusinessCache.PoolTranser = proxySearch.SearchAsync(searchProxy.TokenOffical, ProxySearch.Parameter.Create(settingInfo.Keywords)).Result;
                            }
                            catch (Exception ex)
                            {
                                LogManager.Instance.Error($"{ex.Message}");
                            }

                            var msg = $"{BusinessCache.PoolTranser.TopItem.GetProjectInformation()} {searchProxy.UserName} {settingInfo.FreqTransfer}s+{delay}s";
                            LogManager.Instance.Message(msg);
                        }
                        else
                        {
                            throw new Exception("no proxy found");
                        }

                        Task.Delay((settingInfo.FreqTransfer + delay) * 1000).Wait();
                    };
                    manager.Token.ThrowIfCancellationRequested();
                }
                catch (Exception ex)
                {
                    LogManager.Instance.Error($"{ex.Message}");
                }
                finally
                {
                    manager.Dispose();
                }
            }, manager.Token);
        }

        private string GenerateOverviewInfo()
        {
            var settingInfo = BusinessCache.Settings;
            var keyword = !string.IsNullOrEmpty(settingInfo.Keywords) ? settingInfo.Keywords : "全部";
            var msg = $"关键字: [{keyword}]; ";
            if (settingInfo.Yijia.HasValue)
            {
                msg += $"溢价: [{settingInfo.Yijia.Value}%]; ";
            }
            if (settingInfo.Rate.HasValue)
            {
                msg += $"年化: [{settingInfo.Rate.Value}%]; ";
            }
            return msg;
        }

        #endregion
    }
}
