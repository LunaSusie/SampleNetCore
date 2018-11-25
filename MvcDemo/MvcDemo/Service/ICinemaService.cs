using System.Collections.Generic;
using System.Threading.Tasks;
using MvcDemo.Models;

namespace MvcDemo.Service
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int Id);
        Task AddAsync(Cinema model);
    }
}