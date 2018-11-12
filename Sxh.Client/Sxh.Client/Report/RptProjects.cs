using Shared.Util;
using Sxh.Client.Business;
using Sxh.Client.Business.Repository;
using Sxh.Client.Util;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Sxh.Client.Report
{
    public partial class RptProjects : Form
    {
        public RptProjects()
        {
            InitializeComponent();
        }

        #region Event

        private void RptProjects_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void gridProjects_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            var repo = new LoginRepository();
            BusinessCache.ProjectOverviewList = await repo.SyncDataProjectOverviewAsync(BusinessCache.UserLogin);
            BindData(txtKeyword.Text);
            this.UiFreeze(true);
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            gridProjects.AutoGenerateColumns = false;
            BindData();
        }

        private void BindData(string keyword = null)
        {
            var ds = BusinessCache.ProjectOverviewList.ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                ds = ds.FindAll(p => p.Name.Contains(keyword));
            }
            gridProjects.DataSource = ds;
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
