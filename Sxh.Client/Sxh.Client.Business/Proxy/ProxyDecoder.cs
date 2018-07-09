using Shared.Util.Extension;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Proxy
{
    public class ProxyDecoder
    {
        #region Property

        private const string UserEncrypt = "6365656A6179";
        private string UserName
        {
            get { return UserEncrypt.HexDecrypt(); }
        }

        private const string PasswordEncrypt = "4365654A61793230313621";
        private string Password
        {
            get { return PasswordEncrypt.HexDecrypt(); ; }
        }
        private int AppId
        {
            get { return 5243; }
        }
        private string AppKey
        {
            get { return "666e35f7d6d1c0904f9d11c93b392675"; }
        }
        private int CodeType
        {
            get { return 1005; }
        }
        private int TimeOut
        {
            get { return 20; } //20s
        }

        #endregion

        #region Public Method

        public async Task<string> DecodeAsync(byte[] code)
        {
            return await Task.Run(() => { return DecodeCode(code); });
        }

        #endregion

        #region Private Method

        private string DecodeCode(byte[] code)
        {
            if (code != null && code.Length > 0)
            {
                try
                {
                    var pCodeResult = new StringBuilder(new string(' ', 30));
                    var captchaId = YdmWrapper.YDM_EasyDecodeByBytes(UserName, Password, AppId, AppKey, code, code.Length, CodeType, TimeOut, pCodeResult);
                    var ret = pCodeResult.ToString();
                    if (captchaId > 0 && IsAvailableCode(ret))
                    {
                        return ret;
                    }

                    ReportError(captchaId);
                    return string.Empty;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        private bool IsAvailableCode(string code)
        {
            return Regex.IsMatch(code, @"^[\d|\w]{5}$", RegexOptions.IgnoreCase);
        }

        private bool ReportError(int captchaId)
        {
            try
            {
                YdmWrapper.YDM_EasyReport(UserName, Password, AppId, AppKey, captchaId, false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
