using Sxh.Client.Business;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Util;
using System;
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
    }
}
