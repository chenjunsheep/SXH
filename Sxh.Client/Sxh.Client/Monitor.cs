using System;
using System.Windows.Forms;

namespace Sxh.Client
{
    public partial class Monitor : Form
    {
        public Monitor()
        {
            InitializeComponent();
        }

        #region Event

        public event EventHandler OnWindowClosed;

        private void Monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucProjectInvestmentMonth.Cancel();
        }

        private void Monitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnWindowClosed != null)
            {
                OnWindowClosed.Invoke(sender, e);
            }
        }

        #endregion
    }
}
