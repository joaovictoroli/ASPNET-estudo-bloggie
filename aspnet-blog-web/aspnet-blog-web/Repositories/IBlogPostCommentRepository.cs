using aspnet_blog_web.Models.Domain;

namespace aspnet_blog_web.Repositories
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
        Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid BlogPostId);
    }
}
