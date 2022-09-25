using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;

namespace aspnet_blog_web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;

        [BindProperty]
        public BlogInPost EditablePost { get; set; }

        public EditModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public void OnGet(Guid id)
        {
            EditablePost = blogDbContext.BlogPosts.Find(id);

            //Console.WriteLine(BlogInPost.Content);

        }

        public IActionResult OnPostEdit()
        {
            var postToEdit = blogDbContext.BlogPosts.Find(EditablePost.Id);

            if (postToEdit != null)
            {
                postToEdit.Heading = EditablePost.Heading;
                postToEdit.PageTitle = EditablePost.PageTitle;
                postToEdit.Content = EditablePost.Content;
                postToEdit.ShortDescription = EditablePost.ShortDescription;
                postToEdit.FeaturedImageUrl = EditablePost.FeaturedImageUrl;
                postToEdit.UrlHandle = EditablePost.UrlHandle;
                postToEdit.PublishedDate = EditablePost.PublishedDate;
                postToEdit.Author = EditablePost.Author;
                postToEdit.Visible = EditablePost.Visible;
            }

            blogDbContext.SaveChanges();

            return RedirectToPage("/admin/blogs/list");
        }

        public IActionResult OnPostDelete()
        {
            var existingBlog = blogDbContext.BlogPosts.Find(EditablePost.Id);
            if (existingBlog != null)
            {
                blogDbContext.BlogPosts.Remove(existingBlog);
                blogDbContext.SaveChanges();
            }

            return Page();
        }
    }
}
