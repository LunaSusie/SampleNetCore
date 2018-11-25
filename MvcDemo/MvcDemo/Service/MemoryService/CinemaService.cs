using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcDemo.Models;

namespace MvcDemo.Service.MemoryService
{
    public class CinemaService : ICinemaService
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();

        public CinemaService()
        {
            _cinemas.Add(new Cinema
            {
                Name = "City Cinema",
                Location = "Road ABC,NO.512",
                Capacity = 100,
            });
            _cinemas.Add(new Cinema
            {
                Name = "Fly Cinema",
                Location = "Road Hello,NO.1024",
                Capacity = 500,
            });
        }
        public Task AddAsync(Cinema model)
        {
            var maxId = _cinemas.Max(c => c.Id);
            model.Id = maxId + 1;
            _cinemas.Add(model);
           return Task.CompletedTask; 
        }

        public Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return Task.Run(() => _cinemas.AsEnumerable());
        }

        public Task<Cinema> GetByIdAsync(int Id)
        {
            return Task.Run(() => _cinemas.FirstOrDefault(c=>c.Id==Id));
        }
    }
}