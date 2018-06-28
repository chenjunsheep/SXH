using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Client.Business;
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
                var projectId = grid.Rows[e.RowIndex].Cells["projectId"].Value;
                System.Diagnostics.Process.Start(ProxyBase.CreateUri($"/portionTransferDetail?projectId={projectId}").AbsoluteUri);
            }
        }
    }
}
