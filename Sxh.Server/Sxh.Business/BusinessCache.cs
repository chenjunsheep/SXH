using Sxh.Business.DbProxy;
using Sxh.Db.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sxh.Business
{
    public class BusinessCache
    {
        #region Property

        private static List<User> _users;
        public static List<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new List<User>();

                    using (var db = DbContextFactory.CreateSxhContext())
                    {
                        _users = db.User.ToList();
                    }
                }
                return _users;
            }
            private set { _users = value; }
        }

        #endregion

        #region Public Method

        public static void Load()
        {
            var tmpUser = Users;
        }

        public static void Clear()
        {
            Users = null;
        }

        #endregion
    }
}
