using aspnet_blog_web.Models.Domain;

namespace aspnet_blog_web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(Guid blogInPostId);
        Task AddLikesForBlog(Guid blogInPostId, Guid userId);
        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogInPostId);
    }
}
