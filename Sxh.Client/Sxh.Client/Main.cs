using Sxh.Client.Business;
using Sxh.Client.Business.Logs;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Util;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            LogManager.Instance.Message($"searching task is on aborting, please wait...");
            sender.BottonFreeze(false);
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
                        BusinessCache.PoolTranser = proxySearch.SearchAsync(
                            BusinessCache.UserLogin.TokenOffical, 
                            ProxySearch.Parameter.Create(settingInfo.Keywords)
                        ).Result;
                        var delay = (rd.Next(0, settingInfo.DelayTransfer));
                        LogManager.Instance.Message($"{settingInfo.FreqTransfer}s+{delay}s {BusinessCache.PoolTranser.Count} items were found");
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
                    LogManager.Instance.Message($"searching task has been aborted");
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

        #region Class

        private class CancellationManager
        {
            public CancellationTokenSource Souce { get; set; }
            public CancellationToken Token { get; set; }
            public bool IsCancelled
            {
                get { return Souce == null; }
            }

            public CancellationManager()
            {
                Activate();
            }

            public void Activate()
            {
                Souce = new CancellationTokenSource();
                Token = Souce.Token;
            }

            public void Cancel()
            {
                if (Souce != null)
                {
                    Souce.Cancel();
                }
            }

            public void Dispose()
            {
                if (Souce != null)
                {
                    Souce.Dispose();
                    Souce = null;
                }
            }
        }

        #endregion
    }
}
