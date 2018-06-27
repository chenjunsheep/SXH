using Sxh.Client.Business;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        const int DELAY = 0;
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = !btnStart.Enabled;

            _cmSearching.Activate();
            Task.Factory.StartNew(() => PerformSearching(_cmSearching), _cmSearching.Token);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cmSearching.Cancel();

            btnStop.Enabled = false;
            btnStart.Enabled = !btnStop.Enabled;
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
            var rd = new Random();
            var proxySearch = new ProxySearch();
            try
            {
                while (!manager.Token.IsCancellationRequested)
                {
                    BusinessCache.PoolTranser = proxySearch.SearchAsync(BusinessCache.UserLogin.TokenOffical).Result;
                    var delay = (rd.Next(0, DELAY) + FREQ);
                    Log($"+{delay}s searched");
                    Task.Delay(delay * 1000).Wait();
                };
                manager.Token.ThrowIfCancellationRequested();
            }
            catch (AggregateException ex)
            {
                foreach (var v in ex.InnerExceptions)
                {
                    if (v is TaskCanceledException)
                        Log($"Task {((TaskCanceledException)v).Task.Id} is canceled");
                    else
                        Log($"Exception: {v.ToString()}");
                }
            }
            finally
            {
                manager.Dispose();
            }
        }

        private void Log(string message)
        {
            //lblMessage.Text = $"[{DateTime.Now.ToString("hh:mm:ss")}] {message}";
        }

        #endregion

        #region Class

        private class CancellationManager
        {
            public CancellationTokenSource Souce { get; set; }
            public CancellationToken Token { get; set; }

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
