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

        private static bool _enableSearching = false;

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
            _enableSearching = true;
            UpdateButtons();

            const int FREQ = 5;
            var timeLast = DateTime.Now;
            var rd = new Random();
            var proxySearch = new ProxySearch();
            while (_enableSearching)
            {
                var ret = await proxySearch.SearchAsync(BusinessCache.UserLogin.TokenOffical);
                Log($"{ret.rowSet[0].projectTitle} in ({(DateTime.Now - timeLast).TotalSeconds})s");
                timeLast = DateTime.Now;
                await Task.Delay((rd.Next(0, 10) + FREQ) * 1000);
            }

            UpdateButtons();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _enableSearching = false;
            var btn = sender as Button;
            if (btn != null)
            {
                btn.Enabled = false;
            }
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            UpdateButtons();

            if (BusinessCache.UserLogin.HasValue)
            {
                this.UiFreeze(true);
            }
            else
            {
                this.UiFreeze(false);
            }
        }

        private void UpdateButtons()
        {
            btnStart.Enabled = !_enableSearching;
            btnStop.Enabled = _enableSearching;
        }

        private void Log(string message)
        {
            lblMessage.Text = $"[{DateTime.Now.ToString("hh:mm:ss")}] {message}";
        }

        #endregion
    }
}
