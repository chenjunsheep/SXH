using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Util;
using Sxh.Client.Business;
using Sxh.Client.Business.Logs;
using Sxh.Client.Business.Model;
using Sxh.Client.Business.Proxy;
using Sxh.Shared.Tasks;

namespace Sxh.Client.Controls
{
    public partial class UcPoolTranser : UserControl
    {
        public UcPoolTranser()
        {
            InitializeComponent();
        }

        #region Property

        private Color COLOR_NORMAL = Color.Black;
        private Color COLOR_HIGHLIGHT = Color.Red;

        private CancellationManager _cmPoolReader;
        private CancellationManager CmPoolReader
        {
            get { return _cmPoolReader ?? (_cmPoolReader = new CancellationManager()); }
        }

        private List<int> _targets;
        private List<int> Targets
        {
            get
            {
                if (_targets == null)
                {
                    _targets = new List<int>();
                }
                return _targets;
            }
            set { _targets = value; }
        }

        #endregion

        #region Event

        public event EventHandler OnTargeted;
        public event EventHandler OnDeTargeted;

        private async void UcPoolTranser_Load(object sender, EventArgs e)
        {
            gridTransferPool.AutoGenerateColumns = false;
            await ReadPoolDataAsync();
        }

        private void gridTransferPool_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid != null)
            {
                var projectId = TypeParser.GetInt32Value(grid.Rows[e.RowIndex].Cells[Namespace.GridColProjectId].Value);
                System.Diagnostics.Process.Start(ProxySearch.GetPathTranserDetail(projectId));
            }
        }

        private void gridTransferPool_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid != null)
            {
                var isTargeted = false;
                var settings = BusinessCache.Settings;
                var colName = grid.Columns[e.ColumnIndex].Name;

                switch (colName)
                {
                    case Namespace.GridColProjectType:
                        //cell formatting
                        var typeId = TypeParser.GetInt32Value(grid.Rows[e.RowIndex].Cells[Namespace.GridColProjectTypeId].Value);
                        if (typeId == (int)Business.Model.ProjectType.Binggou)
                        {
                            e.Value = Properties.Resources.ico_bing;
                        }
                        else
                        {
                            e.Value = Properties.Resources.ico_guan;
                        }
                        break;
                    case Namespace.GridColRateDisplay:
                        //rate
                        var isMatchedRate = IsMatchRate(grid, e.RowIndex, settings);
                        isTargeted = IsMatchNextPaymentRemain(grid, e.RowIndex, settings, isMatchedRate);
                        break;
                    case Namespace.GridColYijiaDisplay:
                        //yijia
                        var isMatchedYijia = IsMatchYijia(grid, e.RowIndex, settings);
                        isTargeted = IsMatchNextPaymentRemain(grid, e.RowIndex, settings, isMatchedYijia);
                        break;
                    default:
                        break;
                }

                //e.CellStyle.ForeColor = COLOR_NORMAL;

                if (isTargeted)
                {
                    e.CellStyle.ForeColor = COLOR_HIGHLIGHT;

                    if (!BusinessCache.PoolTranser.IsLocked)
                    {
                        var projectId = TypeParser.GetInt32Value(grid.Rows[e.RowIndex].Cells[Namespace.GridColProjectId].Value);
                        Targets.Add(projectId);
                    }
                }
            }
        }

        private void gridTransferPool_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Targets.Count > 0)
            {
                LogManager.Instance.Message($"==> {GetTargetedProjectInfo()}");

                if (OnTargeted != null)
                {
                    OnTargeted.Invoke(sender, e);
                }
            }
            else
            {
                if (OnDeTargeted != null)
                {
                    OnDeTargeted.Invoke(sender, e);
                }
            }

            Targets.Clear();
        }

        #endregion

        #region Public Method

        public string GetTargetedProjectInfo()
        {
            var msg = string.Empty;
            foreach (var projectId in Targets)
            {
                var targeted = BusinessCache.PoolTranser.GetProjectById(projectId);
                if (targeted != null)
                {
                    msg += targeted.GetProjectInformation();
                }
            }
            return msg;
        }

        public bool PerformTargeted()
        {
            var acquisition = new Acquisition();
            var available = acquisition.SetProjectId(Targets[0]);
            if (available)
            {
                acquisition.ShowDialog();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Private Method

        private async Task<bool> ReadPoolDataAsync()
        {
            CmPoolReader.Activate();
            try
            {
                while (true)
                {
                    if (CmPoolReader.Token.IsCancellationRequested) CmPoolReader.Token.ThrowIfCancellationRequested();

                    var data = new List<ClientPortionTransferItem>();
                    if (BusinessCache.PoolTranser != null)
                    {
                        data = BusinessCache.PoolTranser.rowSet;
                    }
                    gridTransferPool.DataSource = data;
                    await Task.Delay(1000);
                }
            }
            catch (Exception)
            {
                //do nothing
            }
            finally
            {
                CmPoolReader.Dispose();
            }

            return true;
        }

        private bool IsMatchNextPaymentRemain(DataGridView grid, int rowIndex, UserSettings settings, bool seed)
        {
            var status = MatchNextPaymentStatus.UnMatch;

            if (grid == null || settings == null || !settings.NextPayment.HasValue || settings.NextPayment.Value <= 0)
            {
                status = MatchNextPaymentStatus.Invalid;
            }
            else
            {
                var target = TypeParser.GetInt32Value(grid.Rows[rowIndex].Cells[Namespace.GridColNextRemainDay].Value);
                if (target > 0 && target <= settings.NextPayment.Value)
                {
                    status = MatchNextPaymentStatus.Match;
                }
            }

            switch (status)
            {
                case MatchNextPaymentStatus.Invalid:
                    break;
                case MatchNextPaymentStatus.Match:
                    seed = seed && true;
                    if (seed)
                        grid.Rows[rowIndex].Cells[Namespace.GridColNextRemainDayDisplay].Style.ForeColor = COLOR_HIGHLIGHT;
                    break;
                case MatchNextPaymentStatus.UnMatch:
                    seed = false;
                    break;
            }

            return seed;
        }

        private bool IsMatchRate(DataGridView grid, int rowIndex, UserSettings settings)
        {
            if (grid != null && settings != null && settings.Rate.HasValue)
            {
                var target = TypeParser.GetDoubleValue(grid.Rows[rowIndex].Cells[Namespace.GridColRate].Value);
                if (target >= settings.Rate.Value)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsMatchYijia(DataGridView grid, int rowIndex, UserSettings settings)
        {
            if (grid != null && settings != null && settings.Yijia.HasValue)
            {
                var target = TypeParser.GetDoubleValue(grid.Rows[rowIndex].Cells[Namespace.GridColYijia].Value);
                if (target <= settings.Yijia.Value)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        private class Namespace
        {
            public const string GridColProjectId = "projectId";
            public const string GridColProjectName = "projectTitle";
            public const string GridColRate = "minTransferingRate";
            public const string GridColRateDisplay = "DisplayTransferingRate";
            public const string GridColYijia = "Yijia";
            public const string GridColYijiaDisplay = "DisplayYijia";
            public const string GridColNextRemainDay = "NextRemainDay";
            public const string GridColNextRemainDayDisplay = "DisplayNextRemainDay";
            public const string GridColProjectTypeId = "ProjectTypeId";
            public const string GridColProjectType = "ProjectType";
        }

        private enum MatchNextPaymentStatus
        {
            Invalid,
            Match,
            UnMatch,
        }
    }
}
