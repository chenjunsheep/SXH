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
                if (colName == Namespace.GridColRateDisplay)
                {
                    var rate = TypeParser.GetDoubleValue(grid.Rows[e.RowIndex].Cells[Namespace.GridColRate].Value);
                    if (settings.Rate.HasValue && rate >= settings.Rate.Value)
                    {
                        isTargeted = true;
                    }
                }

                if (colName == Namespace.GridColYijiaDisplay)
                {
                    var yijia = TypeParser.GetDoubleValue(grid.Rows[e.RowIndex].Cells[Namespace.GridColYijia].Value);
                    if (settings.Yijia.HasValue && yijia <= settings.Yijia.Value)
                    {
                        isTargeted = true;
                    }
                }

                e.CellStyle.ForeColor = Color.Black;

                if (isTargeted)
                {
                    e.CellStyle.ForeColor = Color.Red;

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
        }
    }
}
