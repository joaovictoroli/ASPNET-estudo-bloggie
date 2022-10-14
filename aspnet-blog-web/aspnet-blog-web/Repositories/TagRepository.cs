using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace aspnet_blog_web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext blogDbContext;

        public TagRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await blogDbContext.Tags.ToListAsync();
            return tags.DistinctBy(x => x.Name.ToLower());
        }
    }
}
