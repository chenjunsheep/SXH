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

        const int DELAY = 10;
        const int FREQ = 5;
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

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = !btnStart.Enabled;

            _cmSearching.Activate();
            PerformSearching(_cmSearching);

            while (!_cmSearching.IsCancelled)
            {
                await Task.Delay(1000);
            }

            btnStart.Enabled = true;
            btnStop.Enabled = !btnStart.Enabled;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            LogManager.Instance.Message($"searching task is on aborting, please wait...");
            btnStop.Enabled = false;
            _cmSearching.Cancel();
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            _cmSearching = new CancellationManager();

            if (BusinessCache.UserLogin.HasValue)
            {
                this.UiFreeze(true);
            }
            else
            {
                this.UiFreeze(false);
            }
        }

        private void PerformSearching(CancellationManager manager)
        {
            Task.Factory.StartNew(() => {
                var rd = new Random();
                var proxySearch = new ProxySearch();
                try
                {
                    while (!manager.Token.IsCancellationRequested)
                    {
                        BusinessCache.PoolTranser = proxySearch.SearchAsync(BusinessCache.UserLogin.TokenOffical).Result;
                        var delay = (rd.Next(0, DELAY));
                        LogManager.Instance.Message($"{FREQ}s+{delay}s searched");
                        Task.Delay((FREQ + delay) * 1000).Wait();
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
