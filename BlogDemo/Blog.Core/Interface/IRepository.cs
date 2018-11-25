using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Create(T entity);
        Task<IEnumerable<T>> GetAllAsync();

    }
}