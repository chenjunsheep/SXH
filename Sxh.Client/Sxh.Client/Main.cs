using Sxh.Client.Business;
using Sxh.Client.Business.Logs;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Util;
using System;
using System.Threading;
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

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private CancellationManager _cmSearching;

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
            ButtonGroupFreeze(true);

            _cmSearching.Activate();
            PerformSearching(_cmSearching);

            while (!_cmSearching.IsCancelled)
            {
                await Task.Delay(1000);
            }

            ButtonGroupFreeze(false);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            LogManager.Instance.Message("cancelling, please wait...");
            sender.CtrlFreeze(false);
            _cmSearching.Cancel();
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
            var msg = string.Join(",", ucPoolTranser.Targets).SubLeftString(10);
            notify.ShowBalloonTip(2000, "Message", msg, ToolTipIcon.None);
        }
        
        private void UcPoolTranser_OnDeTargeted(object sender, EventArgs e)
        {

        }

        private void notify_DoubleClick(object sender, EventArgs e)
        {
            ShowWindow(Handle, 4);
            WindowState = FormWindowState.Normal;
            notify.Visible = false;
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notify.Visible = true;
            }
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            BusinessCache.Settings.TryRetriveFromConfig();

            _cmSearching = new CancellationManager();

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
                            BusinessCache.PoolTranser = proxySearch.SearchAsync(searchProxy.TokenOffical, ProxySearch.Parameter.Create(settingInfo.Keywords)).Result;

                            var msg = $"{BusinessCache.PoolTranser.TopItem.DisplayTransferingRate}/{BusinessCache.PoolTranser.TopItem.DisplayYijia} ";
                            msg += $"{BusinessCache.PoolTranser.TopItem.transferingCopies} ";
                            msg += $"{BusinessCache.PoolTranser.TopItem.projectTitle} ";
                            msg += $"{searchProxy.UserName} {settingInfo.FreqTransfer}s+{delay}s";
                            LogManager.Instance.Message(msg);
                        }
                        else
                        {
                            LogManager.Instance.Message("no proxy found");
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
