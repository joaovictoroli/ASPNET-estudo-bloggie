using aspnet_blog_web.Models.Domain;

namespace aspnet_blog_web.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
