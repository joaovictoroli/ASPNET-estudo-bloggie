using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Models.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_blog_web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;

        public List<BlogInPost> ListPosts { get; set; }

        public ListModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public void OnGet()
        {
            ListPosts = blogDbContext.BlogPosts.ToList();
        }
    }
}
