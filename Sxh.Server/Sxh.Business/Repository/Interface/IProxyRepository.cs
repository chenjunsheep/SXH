using Sxh.Business.ViewModel;
using System.Threading.Tasks;

namespace Sxh.Business.Repository.Interface
{
    public interface IProxyRepository
    {
        Task<string> LoginAsync(vmLogin para);
    }
}
