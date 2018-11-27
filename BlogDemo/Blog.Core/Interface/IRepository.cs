using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.Entities;

namespace Blog.Core.Interface
{
    public interface IRepository<T> where T :class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        Task<PaginatedList<T>> GetAllAsync(PostQueryParameter postQueryParameter);
        Task<T> GetByIdAsync(int id);

    }
}