using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_blog_web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogInPost BlogPost { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await blogPostRepository.GetAsync(urlHandle);
            return Page();
        }
    }
}
