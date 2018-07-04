using System.Net;

namespace Sxh.Client.Business.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordTran { get; set; }

        private CookieCollection _tokenOffical;
        public CookieCollection TokenOffical
        {
            get { return _tokenOffical; }
            set
            {
                _tokenOffical = value;
                BuildTokenDisplayName(value);
            }
        }
        public string DisplayTokenOffical { get; private set; } = "no token";
        public string TokenServer { get; set; }
        public virtual bool HasValue
        {
            get
            {
                return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && TokenOffical != null && TokenOffical.Count > 1;
            }
        }

        private void BuildTokenDisplayName(CookieCollection tokenOffical)
        {
            if (tokenOffical != null && tokenOffical.Count > 1)
            {
                var strToken = string.Empty;
                foreach (Cookie token in tokenOffical)
                {
                    strToken += $"{token.Name}={token.Value};";
                }
                DisplayTokenOffical = strToken;
            }
            else
            {
                DisplayTokenOffical = "invalid token";
            }
        }
    }
}
