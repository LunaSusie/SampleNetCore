using System.Collections.Generic;
using System.Threading.Tasks;
using MvcDemo.Models;

namespace MvcDemo.Service
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);
        Task AddAsync(Cinema model);
    }
}