using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Models.Domain.ViewModel;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_blog_web.Pages.Admin.BlogPost
{
    public class AddModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;

        //asp-for="Heading" in inputype form
        //[BindProperty]
        //public string Heading { get; set; }

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
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
            blogDbContext.BlogPosts.Add(blogPost);
            blogDbContext.SaveChanges();

            return RedirectToPage("/admin/blogs/list");
        }
    }
}

