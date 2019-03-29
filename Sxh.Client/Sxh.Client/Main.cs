using Sxh.Client.Business;
using Sxh.Client.Business.Logs;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Util;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Util.Extension;
using Sxh.Shared.Tasks;
using Shared.Util;
using Sxh.Client.Business.Model;
using Sxh.Client.Report;
using System.Collections.Generic;
using System.Linq;

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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams; cp.ExStyle |= 0x02000000; return cp;
            }
        }

        #endregion

        #region Event

        public event EventHandler OnWindowClosed;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014)
                return;
            base.WndProc(ref m);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认关闭程序吗？", "你正在尝试关闭程序", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
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
            await SearchingClickedAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ucPoolTranser.Off();
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
            UpdateUi();
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

            btnStop.PerformClick();

            var available = ucPoolTranser.PerformTargeted();

            if (available)
            {
                if (BusinessCache.Settings.AutoAcquire)
                {
                    btnStart.PerformClick();
                }
            }
            else
            {
                LogManager.Instance.Message("无可用账户");
            }
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

        private void cbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            var reportId = TypeParser.GetInt32Value(cbReport.SelectedValue);
            switch (reportId)
            {
                case (int)ReportType.ProjectOverview:
                    {
                        var rpt = new RptProjects();
                        rpt.ShowDialog();
                    }
                    break;
                case (int)ReportType.NextPayment:
                    {
                        var rpt = new RptNextPayment();
                        rpt.ShowDialog();
                    }
                    break;
                case (int)ReportType.None:
                    return;
            }

            cbReport.SelectedValue = (int)ReportType.None;
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            BusinessCache.MonitorInfo.Lock();
            btnMonitor.Enabled = false;
            var monitorTransfer = new Monitor();
            //monitorTransfer.StartPosition = FormStartPosition.CenterScreen;
            monitorTransfer.OnWindowClosed -= MonitorTransfer_OnWindowClosed;
            monitorTransfer.OnWindowClosed += MonitorTransfer_OnWindowClosed;
            monitorTransfer.Show();
        }

        private void MonitorTransfer_OnWindowClosed(object sender, EventArgs e)
        {
            BusinessCache.MonitorInfo.UnLock();
            UpdateMonitorButton();
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
            UpdateUi();
            InitializeReport();

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

                        var searchProxy = BusinessCache.UserProxies.GetRandomProxy(settingInfo.PageDiff);
                        if (searchProxy != null)
                        {
                            try
                            {
                                var list = new List<ClientPortionTransferItem>();
                                for (var i = 0; i < settingInfo.SearchingKeywords.Count; i++)
                                {
                                    var searchingKey = settingInfo.SearchingKeywords[i];
                                    for (var j = settingInfo.PageFrom; j <= settingInfo.PageTo; j++)
                                    {
                                        var subList = proxySearch.SearchAsync(searchProxy.TokenOffical, ProxySearch.Parameter.Create(searchingKey, j)).Result;
                                        if (subList != null && subList.Count > 0)
                                            list.AddRange(subList.rowSet);
                                        if (j < settingInfo.PageTo) Task.Delay(1000);
                                    }
                                    if (i < settingInfo.SearchingKeywords.Count - 1) Task.Delay(1000);
                                }

                                BusinessCache.PoolTranser.Clear();
                                BusinessCache.PoolTranser.AddRange(list);
                                BusinessCache.PoolTranser.UpdateFromPayment(BusinessCache.ProjectPayments);
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

                        Task.Delay((settingInfo.FreqTransfer + delay) * 1000).Wait(manager.Token);
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

        private void UpdateUi()
        {
            BindTextMessage();
            BindTextHighlight();
            UpdateMonitorButton();
        }

        private void UpdateMonitorButton()
        {
            btnMonitor.Enabled = BusinessCache.UserTzbProxies.Any(p => p.Enabled) && !BusinessCache.MonitorInfo.IsLocked;
        }

        private void BindTextMessage()
        {
            var settingInfo = BusinessCache.Settings;
            var msg = string.Empty;
            var keyword = settingInfo.MatchingKeywords.Count <= 5 ? string.Join(" & ", settingInfo.MatchingKeywords) : $"{settingInfo.MatchingKeywords.Count}个项目";
            keyword = string.IsNullOrEmpty(keyword) ? "全部" : keyword;
            msg += $"匹配关键字[{keyword}]";
            if (settingInfo.NextPayment.HasValue)
            {
                msg += $" AND 下次付息[≤{settingInfo.NextPayment.Value}天]";
            }

            var msgInner = string.Empty;
            if (settingInfo.Yijia.HasValue)
            {
                msgInner += $" OR 溢价[≤{settingInfo.Yijia.Value}%]";
            }
            if (settingInfo.Rate.HasValue)
            {
                msgInner += $" OR 年化[≥{settingInfo.Rate.Value}%]";
            }
            if (!string.IsNullOrEmpty(msgInner))
            {
                msgInner = msgInner.Substring(4); //remove "OR"
                msg += $" AND ({msgInner})";
            }
            
            lblMessage.Text = msg;
        }

        private void BindTextHighlight()
        {
            var settingInfo = BusinessCache.Settings;
            var msg = string.Empty;
            if (settingInfo.AutoAcquire)
            {
                msg += "已开启自动收购模式";
            }
            lblHighlight.Text = msg;
        }

        private async Task SearchingClickedAsync()
        {
            ucPoolTranser.On();
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

        private void InitializeReport()
        {
            cbReport.Items.Clear();
            cbReport.DisplayMember = "Name";
            cbReport.ValueMember = "Id";

            var items = new[] 
            {
                new { Id = (int)ReportType.None, Name = "选择..." },
                new { Id = (int)ReportType.ProjectOverview, Name = "项目一览表" },
                new { Id = (int)ReportType.NextPayment, Name = "付息计划表" },
            };

            cbReport.DataSource = items;
            cbReport.SelectedValue = (int)ReportType.None;
        }

        #endregion
    }
}
