using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Models.ViewModel;
using aspnet_blog_web.Repositories;
using aspnet_blog_web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace aspnet_blog_web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogInPost EditablePost { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            EditablePost = await blogPostRepository.GetAsync(id);
            if (EditablePost != null && EditablePost.Tags != null) 
            {
                Tags = string.Join(',', EditablePost.Tags.Select(x => x.Name));
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                EditablePost.Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }));        
                    //new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }));

                await blogPostRepository.UpdateAsync(EditablePost);

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
