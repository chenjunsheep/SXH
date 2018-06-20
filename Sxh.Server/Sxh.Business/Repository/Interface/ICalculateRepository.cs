using System.Threading.Tasks;

namespace Sxh.Business.Repository.Interface
{
    public interface ICalculateRepository : IBaseRepository
    {
        Task<int> GeneratePaymentPlan();
    }
}
