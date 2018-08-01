using Sxh.Client.Business.Model;
using Sxh.Client.Business.Proxy;
using System.Threading.Tasks;

namespace Sxh.Client.Business.Repository
{
    public class MonitorRepository : BaseRepository
    {
        public async Task UpdateProjectInvestmentAsync(PeriodType periodType)
        {
            var para = new ProxyProjectInvestment.Parameter() { PeriodType = periodType };
            var proxy = new ProxyProjectInvestment();
            var user = BusinessCache.UserTzbProxies.GetRandomProxy(1);
            if (user != null)
            {
                if (user.HasValue)
                {
                    var ret = await proxy.SearchAsync(user.TokenOffical, para);
                    switch (periodType)
                    {
                        case PeriodType.Day:
                            BusinessCache.MonitorInfo.ProjectInvestmentDay = ret;
                            break;
                        case PeriodType.Month:
                            BusinessCache.MonitorInfo.ProjectInvestmentMonth = ret;
                            break;
                    }
                }
            }
        }
    }
}
