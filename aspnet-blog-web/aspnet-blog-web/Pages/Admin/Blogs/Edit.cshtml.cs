using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Models.ViewModel;
using aspnet_blog_web.Repositories;
using aspnet_blog_web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace aspnet_blog_web.Pages.Admin.Blogs
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public EditBlogPostRequest EditablePost { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        [Required]
        public string Tags { get; set; }

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            var blogPostDomainModel = await blogPostRepository.GetAsync(id);
            
            if (blogPostDomainModel != null && blogPostDomainModel.Tags != null)
            {
                EditablePost = new EditBlogPostRequest
                {
                    Id = blogPostDomainModel.Id,
                    Heading = blogPostDomainModel.Heading,
                    PageTitle = blogPostDomainModel.PageTitle,
                    Content = blogPostDomainModel.Content,
                    ShortDescription = blogPostDomainModel.ShortDescription,   
                    FeaturedImageUrl = blogPostDomainModel.FeaturedImageUrl,    
                    UrlHandle = blogPostDomainModel.UrlHandle,
                    PublishedDate = blogPostDomainModel.PublishedDate,
                    Author = blogPostDomainModel.Author,
                    Visible = blogPostDomainModel.Visible  
                };

                Tags = string.Join(',', blogPostDomainModel.Tags.Select(x => x.Name));
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                var blogPostDomainModel = new BlogInPost
                {
                    Id = EditablePost.Id,
                    Heading = EditablePost.Heading,
                    PageTitle = EditablePost.PageTitle,
                    Content = EditablePost.Content,
                    ShortDescription = EditablePost.ShortDescription,
                    FeaturedImageUrl = EditablePost.FeaturedImageUrl,
                    UrlHandle = EditablePost.UrlHandle,
                    PublishedDate = EditablePost.PublishedDate,
                    Author = EditablePost.Author,
                    Visible = EditablePost.Visible,
                    Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
            };

                await blogPostRepository.UpdateAsync(blogPostDomainModel);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record updated succesfully!",
                    Type = Enums.NotificationType.Success
                };
            }
            catch 
            {
                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Something went wrong!"
                };
            }

            return Page();
            //return RedirectToPage("/admin/blogs/list");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await blogPostRepository.DeleteAsync(EditablePost.Id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Message = "Blog was deleted successfully!",
                    Type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/admin/blogs/list");
            } 
            return Page();
        }
    }
}
