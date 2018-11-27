using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Core.Interface;
using Blog.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repository
{
    public class PostRepository:IRepository<Post>
    {
        private readonly BlogDbContext _blogDbContext;

        public PostRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public IEnumerable<Post> GetAll()
        {
            return _blogDbContext.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return _blogDbContext.Posts.FirstOrDefault(p => p.Id == id);
        }
        public Task<Post> GetByIdAsync(int id)
        {
            return _blogDbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }
        public void Create(Post entity)
        {
            _blogDbContext.Posts.Add(entity);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _blogDbContext.Posts.ToListAsync();
        }

       
    }
}