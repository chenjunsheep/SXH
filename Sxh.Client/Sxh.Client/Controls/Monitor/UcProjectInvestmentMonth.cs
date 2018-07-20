using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Shared.Tasks;
using Sxh.Client.Business.Repository;
using Sxh.Client.Business;

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

        private double? RatePrevious { get; set; }

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
            var strRate = lblRate.Text;
            var strMsg = lblMessage.Text;
            var color = lblRate.ForeColor;

            var topItem = BusinessCache.MonitorInfo.ProjectInvestmentMonth.TopItem;
            if (topItem != null)
            {
                strRate = $"[{topItem.GetActualRate(Business.Model.PeriodType.Month):0.00}%]{topItem.Rate:0.00}%";
                strMsg = $"{topItem.projectSchedule:0.00}% {topItem.memberName}";
                if (RatePrevious.HasValue)
                {
                    if (topItem.Rate > RatePrevious.Value) color = Color.Red;
                    if (topItem.Rate < RatePrevious.Value) color = Color.Green;
                }
                RatePrevious = topItem.Rate;
            }

            lblRate.Text = strRate;
            lblRate.ForeColor = color;
            lblMessage.Text = strMsg;
            lblMessage.ForeColor = color;
        }

        private async Task UpdateProjectInvestmentMonthAsync(CancellationManager cmSelf)
        {
            try
            {
                while (true)
                {
                    if (cmSelf.Token.IsCancellationRequested) cmSelf.Token.ThrowIfCancellationRequested();

                    var proxy = new MonitorRepository();
                    await proxy.UpdateProjectInvestmentAsync(Business.Model.PeriodType.Month);
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
