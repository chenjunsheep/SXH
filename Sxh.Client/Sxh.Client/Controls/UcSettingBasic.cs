using System;
using System.Windows.Forms;
using Sxh.Client.Business;
using Shared.Util;
using Sxh.Client.Util;

namespace Sxh.Client.Controls
{
    public partial class UcSettingBasic : UserControl
    {
        public UcSettingBasic()
        {
            InitializeComponent();
        }

        #region Event

        #endregion

        #region Private Method

        public void Initialize()
        {
            txtKeyword.Text = BusinessCache.Settings.Keywords;
            txtYijia.Text = $"{BusinessCache.Settings.Yijia}";
            txtRate.Text = $"{BusinessCache.Settings.Rate}";
            txtFreqTranser.Text = $"{BusinessCache.Settings.FreqTransfer}";
            txtDelayTransfer.Text = $"{BusinessCache.Settings.DelayTransfer}";
        }

        public bool Save()
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
