using System.Threading.Tasks;
using Blog.Core.Interface;
using Blog.Infrastructure.DataBase;

namespace Blog.Infrastructure.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly BlogDbContext _blogDbContext;

        public UnitOfWork(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<bool> SaveAsync()
        {
            return await _blogDbContext.SaveChangesAsync()>0;
        }
    }
}