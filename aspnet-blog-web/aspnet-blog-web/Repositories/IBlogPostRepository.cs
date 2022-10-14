using aspnet_blog_web.Models.Domain;

namespace aspnet_blog_web.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogInPost>> GetAllAsync();

        Task<IEnumerable<BlogInPost>> GetAllAsync(string tagName);

        Task<BlogInPost> GetAsync(Guid id);

        Task<BlogInPost> GetAsync(string urlHandle);

        Task<BlogInPost> AddAsync(BlogInPost post);

        Task<BlogInPost> UpdateAsync(BlogInPost post);

        Task<bool> DeleteAsync(Guid id);

    }
}
