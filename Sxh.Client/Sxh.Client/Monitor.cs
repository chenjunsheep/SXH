using Sxh.Client.Business;
using Sxh.Client.Business.Proxy;
using Sxh.Client.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucProjectInvestmentMonth.Cancel();
        }

        #endregion
    }
}
