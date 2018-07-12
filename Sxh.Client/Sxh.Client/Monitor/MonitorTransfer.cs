using Sxh.Client.Business;
using Sxh.Shared.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sxh.Client.Monitor
{
    public partial class MonitorTransfer : Form
    {
        public MonitorTransfer()
        {
            InitializeComponent();
        }

        #region Property

        private Point _downPoint;
        const string NO_VALUE = "------";
        private double? PreRate { get; set; }

        private CancellationManager _cmMonitor;
        private CancellationManager CmMonitor
        {
            get { return _cmMonitor ?? (_cmMonitor = new CancellationManager()); }
        }

        #endregion

        #region Event

        private async void MonitorTransfer_Load(object sender, EventArgs e)
        {
            CmMonitor.Activate();

            try
            {
                while (true)
                {
                    if (CmMonitor.Token.IsCancellationRequested) CmMonitor.Token.ThrowIfCancellationRequested();
                    BindValue();
                    await Task.Delay(1000);
                }
            }
            catch (Exception)
            {
                //do nothing
            }
            finally
            {
                CmMonitor.Dispose();
            }
        }

        private void lblMessage_DoubleClick(object sender, EventArgs e)
        {
            CmMonitor.Cancel();
            Close();
        }

        private void lblMessage_MouseDown(object sender, MouseEventArgs e)
        {
            _downPoint = new Point(e.X, e.Y);
        }

        private void lblMessage_MouseMove(object sender, MouseEventArgs e)
        {
            var form = FindForm();
            if (form != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    form.Location = new Point(form.Location.X + e.X - _downPoint.X, form.Location.Y + e.Y - _downPoint.Y);
                }
            }
        }

        #endregion

        #region Private Method

        private void BindValue()
        {
            var color = lblMessage.ForeColor;
            var msg = NO_VALUE;
            var rate = BusinessCache.PoolTranser.TopItem.minTransferingRate;
            if (rate.HasValue)
            {
                if (PreRate.HasValue)
                {
                    msg = $"{rate.Value}%";

                    if (PreRate.Value > rate.Value)
                    {
                        color = Color.Green;
                    }
                    else if (PreRate.Value < rate.Value)
                    {
                        color = Color.Red;
                    }
                }
            }

            PreRate = rate;

            lblMessage.ForeColor = color;
            lblMessage.Text = msg;
        }

        #endregion
    }
}
