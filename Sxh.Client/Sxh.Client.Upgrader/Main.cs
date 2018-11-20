using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Worker = Sxh.Client.Upgrader.Business;

namespace Sxh.Client.Upgrader
{
    public partial class Main : Form
    {
        #region Property

        private bool IsLoaded { get; set; }
        public delegate void UpdateUI(int step);
        public UpdateUI UpdateUiDelegate;
        public Worker.Upgrader UpgradeManager { get; set; }

        #endregion


        public Main()
        {
            InitializeComponent();
        }

        #region Event

        private void Main_Load(object sender, EventArgs e)
        {
            if (!IsLoaded)
            {
                Init();
                ProgressReports();
            }
        }

        #endregion

        #region Private

        private void Init()
        {
            UpdateUiDelegate = new UpdateUI((val) =>
            {
                if (val > 0)
                    probar.Value = val;
                else
                    Close();
            });
            UpgradeManager.OnUpdateProgess += new Worker.Upgrader.UpdateProgess((val) =>
            {

                Invoke(UpdateUiDelegate, (int)val);
            });
        }

        private void ProgressReports()
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                try
                {
                    UpgradeManager.Excute();
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Invoke(UpdateUiDelegate, -1);
                }
            });
        }

        #endregion
    }
}
