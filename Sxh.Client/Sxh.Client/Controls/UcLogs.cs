using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sxh.Client.Business.Logs;

namespace Sxh.Client.Controls
{
    public partial class UcLogs : UserControl
    {
        public UcLogs()
        {
            InitializeComponent();
        }

        private async void UcLogs_Load(object sender, EventArgs e)
        {
            while (true)
            {
                var logs = LogManager.Instance.GetAll();
                foreach (var log in logs)
                {
                    txtMessage.Text = $"{log.Memo}\r\n{txtMessage.Text}";
                }
                await Task.Delay(1000);
            }
        }

        private void txtMessage_DoubleClick(object sender, EventArgs e)
        {
            txtMessage.Text = string.Empty;
        }
    }
}
