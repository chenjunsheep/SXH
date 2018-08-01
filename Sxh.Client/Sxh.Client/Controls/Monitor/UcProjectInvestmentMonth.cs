using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Shared.Tasks;
using Sxh.Client.Business.Repository;
using Sxh.Client.Business;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.Logs;

namespace Sxh.Client.Controls.Monitor
{
    public partial class UcProjectInvestmentMonth : UserControl
    {
        public UcProjectInvestmentMonth()
        {
            InitializeComponent();
        }

        #region Property

        const int FREQ_UPDATE = 30000;
        const int FREQ_REFRESH = 1000;

        private CancellationManager _cmUpdate;
        private CancellationManager CmUpdate
        {
            get { return _cmUpdate ?? (_cmUpdate = new CancellationManager()); }
        }

        private CancellationManager _cmRefresh;
        private CancellationManager CmRefresh
        {
            get { return _cmRefresh ?? (_cmRefresh = new CancellationManager()); }
        }

        private ClientProjectInvestmentItem Flag { get; set; }
        private DateTime LastUpdate { get; set; } = DateTime.Now;

        #endregion

        #region Event

        private async void UcProjectInvestmentMonth_Load(object sender, EventArgs e)
        {
            CmRefresh.Activate();
            await RefreshAsync(CmRefresh);
        }

        private async void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                CmUpdate.Activate();
                Flag = null;
                await UpdateProjectInvestmentMonthAsync(CmUpdate);
            }
            else
            {
                CmUpdate.Cancel();
            }
        }

        #endregion

        #region Public Method

        public void Cancel()
        {
            CmRefresh.Cancel();
            CmUpdate.Cancel();
        }

        #endregion

        #region Private Method

        private void BindMessage()
        {
            var current = BusinessCache.MonitorInfo.ProjectInvestmentMonth.TopItem;
            if (current != null)
            {
                BuildMessage(current, BusinessCache.MonitorInfo.ProjectInvestmentMonth.rowSet.FindAll(i => i.Rate == current.Rate).Count);
            }
        }

        private void BuildMessage(ClientProjectInvestmentItem current, int total)
        {
            if (Flag == null)
            {
                var strRate = $"[{total}]{current.Rate:0.00} ({current.GetActualRate(PeriodType.Month):0.00})%";
                var strMsg = $"进度：{current.projectSchedule:0.00}% {current.memberName} 上次更新：{LastUpdate.ToString("HH:mm:ss")}";
                var color = Color.DarkGray;
                lblRate.Text = strRate;
                lblMessage.Text = strMsg;
                lblRate.ForeColor = color;
                lblMessage.ForeColor = color;

                Flag = current;
            }
            else if (Flag.id == current.id)
            {
                var strMsg = $"进度：{current.projectSchedule:0.00}% {current.memberName} 上次更新：{LastUpdate.ToString("HH:mm:ss")}";
                lblMessage.Text = strMsg;
            }
            else
            {
                var diffRate = current.Rate - Flag.Rate;
                var mark = string.Empty;
                if (diffRate > 0) mark = "+";
                if (diffRate < 0) mark = "-";
                var strDiffRate = $"{Math.Abs(diffRate):0.00}";
                if (!string.IsNullOrEmpty(mark)) strDiffRate = $"{mark}{strDiffRate}";

                var strRate = $"[{total}]{current.Rate:0.00} ({current.GetActualRate(PeriodType.Month):0.00})% {strDiffRate}%";
                var strMsg = $"进度：{current.projectSchedule:0.00}% {current.memberName} 上次更新：{LastUpdate.ToString("HH:mm:ss")}";
                var color = lblRate.ForeColor;
                if (diffRate > 0) color = Color.Red;
                if (diffRate < 0) color = Color.Green;
                lblRate.Text = strRate;
                lblMessage.Text = strMsg;
                lblRate.ForeColor = color;
                lblMessage.ForeColor = color;

                //Flag = current;
            }
        }

        private async Task UpdateProjectInvestmentMonthAsync(CancellationManager cmSelf)
        {
            try
            {
                while (true)
                {
                    if (cmSelf.Token.IsCancellationRequested) cmSelf.Token.ThrowIfCancellationRequested();

                    var proxy = new MonitorRepository();
                    try
                    {
                        await proxy.UpdateProjectInvestmentAsync(PeriodType.Month);
                    }
                    catch (Exception ex)
                    {
                        LogManager.Instance.Error($"{ex.Message}");
                    }
                    LastUpdate = DateTime.Now;
                    await Task.Delay(FREQ_UPDATE);
                }
            }
            catch (Exception)
            {
                //do nothing
            }
            finally
            {
                cmSelf.Dispose();
            }
        }

        private async Task RefreshAsync(CancellationManager cmSelf)
        {
            try
            {
                while (true)
                {
                    if (cmSelf.Token.IsCancellationRequested) cmSelf.Token.ThrowIfCancellationRequested();
                    BindMessage();
                    await Task.Delay(FREQ_REFRESH);
                }
            }
            catch (Exception)
            {
                //do nothing
            }
            finally
            {
                cmSelf.Dispose();
            }
        }

        #endregion
    }
}
