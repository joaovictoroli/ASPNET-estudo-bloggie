using aspnet_blog_web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace aspnet_blog_web.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<BlogInPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
