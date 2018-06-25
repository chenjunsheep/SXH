using Sxh.Client.Business;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            lblToken.Text = BusinessCache.UserLogin.TokenOffical;
        }

        public event EventHandler OnWindowClosed;

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnWindowClosed != null)
            {
                OnWindowClosed.Invoke(sender, e);
            }
        }
    }
}
