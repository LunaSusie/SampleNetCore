using System.Collections.Generic;
using System.Threading.Tasks;
using MvcDemo.Models;

namespace MvcDemo.Service
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId);
        Task AddAsync(Movie model);
    }
}