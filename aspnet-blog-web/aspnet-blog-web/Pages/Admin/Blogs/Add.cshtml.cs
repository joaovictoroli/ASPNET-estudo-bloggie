using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Models.Domain.ViewModel;
using aspnet_blog_web.Models.ViewModel;
using aspnet_blog_web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace aspnet_blog_web.Pages.Admin.BlogPost
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        [Required]
        public string Tags { get; set; }
        public AddModel(IBlogPostRepository  blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            ValidateAddBlogPost();

            if (ModelState.IsValid)
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
                    Visible = AddBlogPostRequest.Visible,
                    Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
                };
                await blogPostRepository.AddAsync(blogPost);

                var notification = new Notification
                {
                    Message = "New blog created!",
                    Type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/admin/blogs/list");
            }

            return Page();
        }

        private void ValidateAddBlogPost()
        {
            if(AddBlogPostRequest.PublishedDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("AddBlogPostRequest.PublishedDate",
                    $"{nameof(AddBlogPostRequest.PublishedDate)} can only be today's date or a future date.");
            }
        }
    }
}

