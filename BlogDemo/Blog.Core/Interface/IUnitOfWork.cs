using System.Threading.Tasks;

namespace Blog.Core.Interface
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}