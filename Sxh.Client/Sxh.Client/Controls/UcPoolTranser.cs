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

namespace Sxh.Client.Controls
{
    public partial class UcPoolTranser : UserControl
    {
        public UcPoolTranser()
        {
            InitializeComponent();
        }

        #region Property

        private List<string> _targets;
        public List<string> Targets
        {
            get
            {
                if (_targets == null)
                {
                    _targets = new List<string>();
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

            while (true)
            {
                var data = new List<ClientPortionTransferItem>();
                if (BusinessCache.PoolTranser != null)
                {
                    data = BusinessCache.PoolTranser.rowSet;
                }
                gridTransferPool.DataSource = data;
                await Task.Delay(1000);
            }
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
                var msgTarget = string.Empty;
                var settings = BusinessCache.Settings;
                if (e.ColumnIndex == 4) //rate displaying field index
                {
                    var rate = TypeParser.GetDoubleValue(grid.Rows[e.RowIndex].Cells[Namespace.GridColRate].Value);
                    if (settings.Rate.HasValue && rate >= settings.Rate.Value)
                    {
                        msgTarget += $" {settings.Rate.Value}% ";
                    }
                }

                if (e.ColumnIndex == 5) //yijia displaying field index
                {
                    var yijia = TypeParser.GetDoubleValue(grid.Rows[e.RowIndex].Cells[Namespace.GridColYijia].Value);
                    if (settings.Yijia.HasValue && yijia <= settings.Yijia.Value)
                    {
                        msgTarget += $" {settings.Yijia.Value}% ";
                    }
                }

                e.CellStyle.ForeColor = Color.Black;

                if (!string.IsNullOrEmpty(msgTarget))
                {
                    e.CellStyle.ForeColor = Color.Red;

                    var projectName = TypeParser.GetStringValue(grid.Rows[e.RowIndex].Cells[Namespace.GridColProjectName].Value);
                    Targets.Add($"{projectName} {msgTarget}");
                }
            }
        }

        private void gridTransferPool_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Targets.Count > 0)
            {
                LogManager.Instance.Message($"==> {string.Join(", ", Targets)}");

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

        private class Namespace
        {
            public const string GridColProjectId = "projectId";
            public const string GridColProjectName = "projectTitle";
            public const string GridColRate = "minTransferingRate";
            public const string GridColYijia = "Yijia";
        }
    }
}
