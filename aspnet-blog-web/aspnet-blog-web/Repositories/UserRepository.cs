using aspnet_blog_web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace aspnet_blog_web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext authDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public UserRepository(AuthDbContext authDbContext,
                            UserManager<IdentityUser> userManager)
        {
            this.authDbContext = authDbContext;
            this.userManager = userManager;
        }

        public async Task<bool> Add(IdentityUser identityUser, string password, List<string> roles)
        {
            var identityresult = await userManager.CreateAsync(identityUser, password);
            
            if (identityresult.Succeeded)
            {
                identityresult = await userManager.AddToRolesAsync(identityUser, roles);

                if (identityresult.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
        }

        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await authDbContext.Users.ToListAsync();
            var superAdminUser = await authDbContext.Users
                .FirstOrDefaultAsync(x => x.Email == "superadmin@bloggie.com");

            if (superAdminUser != null)
            {
                users.Remove(superAdminUser);
            }

            return users;
        }
    }
}
