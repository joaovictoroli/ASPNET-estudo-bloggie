using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Models.Domain.ViewModel;
using aspnet_blog_web.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_blog_web.Pages.Admin.BlogPost
{
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        //asp-for="Heading" in inputype form
        //[BindProperty]
        //public string Heading { get; set; }

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(IBlogPostRepository  blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var blogPost = new BlogInPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible
            };
            await blogPostRepository.AddAsync(blogPost);

            return RedirectToPage("/admin/blogs/list");
        }
    }
}

