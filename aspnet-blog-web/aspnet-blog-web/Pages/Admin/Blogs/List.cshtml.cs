using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Models.Domain.ViewModel;
using aspnet_blog_web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace aspnet_blog_web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogInPost> ListPosts { get; set; }

        public ListModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet()
        {
            ListPosts = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
