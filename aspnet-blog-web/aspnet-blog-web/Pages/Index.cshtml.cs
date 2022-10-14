using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_blog_web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogInPost> Blogs { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostRepository blogPostRepository)
        {
            _logger = logger;
            this.blogPostRepository = blogPostRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Blogs = (await blogPostRepository.GetAllAsync()).ToList();
            return Page();
        }
    }
}