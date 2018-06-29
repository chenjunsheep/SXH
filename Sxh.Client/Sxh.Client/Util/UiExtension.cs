using Shared.Util;
using Sxh.Client.Business.Model;
using System.Configuration;
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

        public static bool BottonFreeze(this object obj, bool enable)
        {
            var btn = obj as Button;
            if (btn == null)
            {
                btn = new Button();
            }
            btn.Enabled = enable;
            return enable;
        }

        public static void TryRetriveFromConfig(this UserSettings setting)
        {
            if (setting == null) setting = new UserSettings();
            setting.Keywords = TypeParser.GetStringValue(ConfigurationManager.AppSettings[UserSettings.Namespance.Keyword]);
            setting.Yijia = TypeParser.GetDouble(ConfigurationManager.AppSettings[UserSettings.Namespance.Yijia]);
            setting.Rate = TypeParser.GetDouble(ConfigurationManager.AppSettings[UserSettings.Namespance.Rate]);
            setting.FreqTransfer = TypeParser.GetInt32Value(ConfigurationManager.AppSettings[UserSettings.Namespance.FreqTransfer], 60);
            setting.DelayTransfer = TypeParser.GetInt32Value(ConfigurationManager.AppSettings[UserSettings.Namespance.DelayTransfer]);
        }

        public static void TrySaveToConfig(this UserSettings setting)
        {
            if (setting != null)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[UserSettings.Namespance.Keyword].Value = setting.Keywords;
                config.AppSettings.Settings[UserSettings.Namespance.Yijia].Value = TypeParser.GetStringValue(setting.Yijia);
                config.AppSettings.Settings[UserSettings.Namespance.Rate].Value = TypeParser.GetStringValue(setting.Rate);
                config.AppSettings.Settings[UserSettings.Namespance.FreqTransfer].Value = TypeParser.GetStringValue(setting.FreqTransfer);
                config.AppSettings.Settings[UserSettings.Namespance.DelayTransfer].Value = TypeParser.GetStringValue(setting.DelayTransfer);
                config.Save(ConfigurationSaveMode.Modified);
            }
        }
    }
}
