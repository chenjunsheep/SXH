using Shared.Util;
using Sxh.Client.Business;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Util;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sxh.Client.Report
{
    public partial class RptNextPayment : Form
    {
        public RptNextPayment()
        {
            InitializeComponent();
        }

        #region Event

        private void RptNextPayment_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void gridNextPayment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid != null)
            {
                var colName = grid.Columns[e.ColumnIndex].Name;
                if (colName == Namespace.GridColProjectType)
                {
                    var typeId = TypeParser.GetInt32Value(grid.Rows[e.RowIndex].Cells[Namespace.GridColProjectTypeId].Value);
                    if (typeId == (int)Business.Model.ProjectType.Binggou)
                    {
                        e.Value = Properties.Resources.ico_bing;
                    }
                    else
                    {
                        e.Value = Properties.Resources.ico_guan;
                    }
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            this.UiFreeze(false);
            await SyncServerDataAsync();
            BindData();
            this.UiFreeze(true);
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            gridNextPayment.AutoGenerateColumns = false;
            BindData();
        }

        private void BindData()
        {
            gridNextPayment.DataSource = BusinessCache.ProjectPayments;
        }

        private async Task SyncServerDataAsync()
        {
            var proxy = new ProxyServer();
            var dataPayments = await proxy.SyncData();
            BusinessCache.ProjectPayments = dataPayments;
        }

        #endregion

        #region Class

        private class Namespace
        {
            public const string GridColProjectTypeId = "ProjectTypeId";
            public const string GridColProjectType = "ProjectType";
        }

        #endregion
    }
}
