using Microsoft.AspNetCore.Identity;

namespace aspnet_blog_web.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();

        Task<bool> Add(IdentityUser identityUser, string password, List<string> roles);

        Task Delete(Guid userId);
    }
}
