using System.Windows.Forms;

namespace Sxh.Client.Util
{
    public static class UiExtension
    {
        public static void UiFreeze(this Form from, bool enable)
        {
            if (from != null)
            {
                foreach (Control ctr in from.Controls)
                {
                    ctr.Enabled = enable;
                }
            }
        }
    }
}
