﻿using System.Net;

namespace Sxh.Client.Business.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordTran { get; set; }
        public CookieCollection TokenOffical { get; set; }
        public string TokenServer { get; set; }
        public bool HasValue
        {
            get
            {
                return TokenOffical != null && TokenOffical.Count > 0;
            }
        }
    }
}