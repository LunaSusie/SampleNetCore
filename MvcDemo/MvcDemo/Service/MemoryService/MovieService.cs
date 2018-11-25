using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcDemo.Models;

namespace MvcDemo.Service.MemoryService
{
    public class MovieService : IMovieService
    {
        private readonly List<Movie> _movies = new List<Movie>();

        public MovieService()
        {
            _movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 1,
                Name = "Super Man",
                ReleaseTime = new DateTime(2018, 10, 1),
                Starring = "Nick"

            });
            _movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 2,
                Name = "Ghost",
                ReleaseTime = new DateTime(1997, 10, 1),
                Starring = "Micheal Jackson"
            });
            _movies.Add(new Movie
            {
                CinemaId = 2,
                Id = 3,
                Name = "Fight",
                ReleaseTime = new DateTime(2018, 12, 3),
                Starring = "Tommy"
            });
        }
        public Task AddAsync(Movie model)
        {
            var maxId = _movies.Max(s => s.Id);
            model.Id = maxId + 1;
            _movies.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId)
        {
            return Task.Run(() => _movies.Where(s => s.CinemaId == cinemaId));
        }
    }
}