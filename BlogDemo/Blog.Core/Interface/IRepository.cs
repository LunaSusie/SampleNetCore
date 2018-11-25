using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

    }
}