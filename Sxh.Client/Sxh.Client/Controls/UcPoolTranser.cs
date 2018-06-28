using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Client.Business;
using Sxh.Client.Business.Model;

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
    }
}
