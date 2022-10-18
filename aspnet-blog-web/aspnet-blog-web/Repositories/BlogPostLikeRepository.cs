using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace aspnet_blog_web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogDbContext blogDbContext;

        public BlogPostLikeRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public async Task<int> GetTotalLikesForBlog(Guid blogInPostId)
        {
            return await blogDbContext.BlogPostLike
                .CountAsync(x => x.BlogInPostId == blogInPostId);
        }

        public async Task AddLikesForBlog(Guid blogInPostId, Guid userId)
        {
            var like = new BlogPostLike
            {
                Id = Guid.NewGuid(),
                BlogInPostId = blogInPostId,
                UserId = userId,
            };
            await blogDbContext.BlogPostLike.AddAsync(like);
            await blogDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogInPostId)
        {
            return await blogDbContext.BlogPostLike.Where(x => x.BlogInPostId == blogInPostId)
                        .ToListAsync();
        }
    }
}
