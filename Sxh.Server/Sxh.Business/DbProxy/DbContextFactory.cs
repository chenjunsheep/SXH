using Sxh.Db.Models;

namespace Sxh.Business.DbProxy
{
    public class DbContextFactory
    {
        public static SxhContext CreateSxhContext()
        {
            return new SxhContext(AppSetting.Instance.DbConnection.Sxh);
        }
    }
}
