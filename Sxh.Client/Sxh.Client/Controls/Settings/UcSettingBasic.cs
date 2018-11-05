using System.Windows.Forms;
using Sxh.Client.Business;
using Shared.Util;
using Sxh.Client.Util;

namespace Sxh.Client.Controls.Settings
{
    public partial class UcSettingBasic : UserControl
    {
        public UcSettingBasic()
        {
            InitializeComponent();
        }

        #region Event

        #endregion

        #region Public Method

        public void Initialize()
        {
            txtSearchingKeyword.Text = BusinessCache.Settings.SearchingKeywordsString;
            txtMatchKeyword.Text = BusinessCache.Settings.MatchingKeywordsString;
            txtYijia.Text = $"{BusinessCache.Settings.Yijia}";
            txtRate.Text = $"{BusinessCache.Settings.Rate}";
            txtNextPayment.Text = $"{BusinessCache.Settings.NextPayment}";
            txtFreqTranser.Text = $"{BusinessCache.Settings.FreqTransfer}";
            txtDelayTransfer.Text = $"{BusinessCache.Settings.DelayTransfer}";
            txtTotalPage.Text = $"{BusinessCache.Settings.TotalPage}";
            chkAutoAcquire.Checked = BusinessCache.Settings.AutoAcquire;
        }

        public bool Save()
        {
            BusinessCache.Settings.SearchingKeywordsString = txtSearchingKeyword.Text;
            BusinessCache.Settings.MatchingKeywordsString = FormatMatchingKeywords(txtMatchKeyword.Text);
            BusinessCache.Settings.Yijia = TypeParser.GetDouble(txtYijia.Text);
            BusinessCache.Settings.Rate = TypeParser.GetDouble(txtRate.Text);
            BusinessCache.Settings.NextPayment = TypeParser.GetInt(txtNextPayment.Text);
            BusinessCache.Settings.FreqTransfer = TypeParser.GetInt32Value(txtFreqTranser.Text, 60);
            BusinessCache.Settings.DelayTransfer = TypeParser.GetInt32Value(txtDelayTransfer.Text);
            BusinessCache.Settings.TotalPage = TypeParser.GetInt32Value(txtTotalPage.Text);
            BusinessCache.Settings.AutoAcquire = chkAutoAcquire.Checked;
            BusinessCache.Settings.TrySaveToConfig();
            return true;
        }

        #endregion

        #region Private Method

        private string FormatMatchingKeywords(string inputKeyword)
        {
            var outputKeyword = TypeParser.GetStringValue(inputKeyword).Trim().TrimStart(new char[] { ';' }).TrimEnd(new char[] { ';' });
            return outputKeyword;
        }

        #endregion
    }
}
