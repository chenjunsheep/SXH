using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Shared.Tasks;
using Sxh.Client.Business;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.Repository;
using Sxh.Client.Business.Logs;

namespace Sxh.Client.Controls.Monitor
{
    public partial class UcProjectReverse : UserControl
    {
        public UcProjectReverse()
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
        
        private DateTime? LastUpdate { get; set; }

        #endregion

        #region Event

        private async void UcProjectReverse_Load(object sender, EventArgs e)
        {
            CmRefresh.Activate();
            await RefreshAsync(CmRefresh);
        }

        private async void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                CmUpdate.Activate();
                await UpdateProjectReverseAsync(CmUpdate);
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
            var current = BusinessCache.MonitorInfo.ProjectReverse.BestItem;
            BuildMessage(current);
        }

        private void BuildMessage(ClientProjectReverseItem current)
        {
            if (LastUpdate.HasValue)
            {
                if (current != null)
                {
                    lblRate.Text = $"{current.rate:0.00} ({current.RateActual:0.00})% {current.amount} {current.period}{current.repaymentStrategy.periodUnit}";
                }
                else
                {
                    lblRate.Text = "无可用标的";
                }
                var strMsg = $"上次更新：{LastUpdate.Value.ToString("HH:mm:ss")}";
                lblMessage.Text = strMsg;
            }
        }

        private async Task UpdateProjectReverseAsync(CancellationManager cmSelf)
        {
            try
            {
                while (true)
                {
                    if (cmSelf.Token.IsCancellationRequested) cmSelf.Token.ThrowIfCancellationRequested();

                    var proxy = new MonitorRepository();
                    try
                    {
                        await proxy.UpdateProjectReverseAsync();
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
