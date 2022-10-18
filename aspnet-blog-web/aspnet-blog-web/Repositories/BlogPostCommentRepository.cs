using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace aspnet_blog_web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogDbContext blogDbContext;

        public BlogPostCommentRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await blogDbContext.BlogPostComment.AddAsync(blogPostComment);
            await blogDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid BlogPostId)
        {
            return await blogDbContext.BlogPostComment.Where(x => x.BlogInPostId == BlogPostId)
                .ToListAsync();
        }
    }
}
