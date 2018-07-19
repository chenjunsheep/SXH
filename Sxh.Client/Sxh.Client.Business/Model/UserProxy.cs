using System.Net;

namespace Sxh.Client.Business.Model
{
    public class UserProxy : User
    {
        public bool Enabled { get; set; }
        public int Weight { get; set; }
        public CookieCollection TokenTzb { get; private set; }
        public bool AvailableInTzb
        {
            get
            {
                return TokenTzb != null && TokenTzb.Count > 1;
            }
        }

        public void SetTokenTzb(CookieCollection token)
        {
            TokenTzb = token;
        }
    }
}
