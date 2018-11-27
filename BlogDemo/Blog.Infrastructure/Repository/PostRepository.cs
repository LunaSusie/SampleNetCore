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

        public async Task<PaginatedList<Post>> GetAllAsync(PostQueryParameter postQueryParameter)
        {
            var query = _blogDbContext.Posts.OrderBy(x => x.Id);
            var count = await query.CountAsync();
            var data= await query.Skip(postQueryParameter.PageIndex * postQueryParameter.PageSize).Take(postQueryParameter.PageSize).ToListAsync();
            return new PaginatedList<Post>(postQueryParameter.PageIndex, postQueryParameter.PageSize, count, data);
        }

       
    }
}