using Shared.Util;
using Sxh.Client.Business;
using Sxh.Client.Util;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sxh.Client
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        #region Event

        public event EventHandler OnWindowClosed;

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnWindowClosed != null)
            {
                OnWindowClosed.Invoke(sender, e);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.UiFreeze(false);
            Save();
            Close();
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            txtKeyword.Text = BusinessCache.Settings.Keywords;
            txtYijia.Text = $"{BusinessCache.Settings.Yijia}";
            txtRate.Text = $"{BusinessCache.Settings.Rate}";
            txtFreqTranser.Text = $"{BusinessCache.Settings.FreqTransfer}";
            txtDelayTransfer.Text = $"{BusinessCache.Settings.DelayTransfer}";
        }

        private bool Save()
        {
            BusinessCache.Settings.Keywords = txtKeyword.Text;
            BusinessCache.Settings.Yijia = TypeParser.GetDouble(txtYijia.Text);
            BusinessCache.Settings.Rate = TypeParser.GetDouble(txtRate.Text);
            BusinessCache.Settings.FreqTransfer = TypeParser.GetInt32Value(txtFreqTranser.Text, 60);
            BusinessCache.Settings.DelayTransfer = TypeParser.GetInt32Value(txtDelayTransfer.Text);
            BusinessCache.Settings.TrySaveToConfig();
            return true;
        }

        #endregion

        
    }
}
