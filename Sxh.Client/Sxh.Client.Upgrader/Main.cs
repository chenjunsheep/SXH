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
        public delegate void UpdateUI(Worker.Upgrader.Parameter para);
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
            UpdateUiDelegate = new UpdateUI((para) =>
            {
                lblMessage.Text = para.Message;

                if (para.Step > 0)
                    probar.Value = para.Step;
                else
                    Close();
            });

            UpgradeManager.OnUpdateProgess += new Worker.Upgrader.UpdateProgess((para) =>
            {

                Invoke(UpdateUiDelegate, para);
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
                    Invoke(UpdateUiDelegate, Worker.Upgrader.Parameter.Create(-1, string.Empty));
                }
            });
        }

        #endregion
    }
}
