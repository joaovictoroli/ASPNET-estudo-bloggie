using aspnet_blog_web.Data;
using aspnet_blog_web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace aspnet_blog_web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDbContext blogDbContext;

        public BlogPostRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<BlogInPost> AddAsync(BlogInPost blogPost)
        {
            await blogDbContext.BlogPosts.AddAsync(blogPost);
            await blogDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlog = await blogDbContext.BlogPosts.FindAsync(id);

            if (existingBlog != null)
            {
                blogDbContext.BlogPosts.Remove(existingBlog);
                await blogDbContext.SaveChangesAsync();
                return true;
            }
            return false;   
        }

        public async Task<IEnumerable<BlogInPost>> GetAllAsync()
        {
            return await blogDbContext.BlogPosts.Include(nameof(BlogInPost.Tags)).ToListAsync();
        }
        public async Task<IEnumerable<BlogInPost>> GetAllAsync(string tagName)
        {
            return await (blogDbContext.BlogPosts.Include(nameof(BlogInPost.Tags))
                .Where(x => x.Tags.Any(x => x.Name == tagName)))
                .ToListAsync();
        }

        public async Task<BlogInPost> GetAsync(Guid id)
        {
            return await blogDbContext.BlogPosts.Include(nameof(BlogInPost.Tags))
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        async Task<BlogInPost> IBlogPostRepository.GetAsync(string urlHandle)
        {
            return await blogDbContext.BlogPosts.Include(nameof(BlogInPost.Tags))
                .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogInPost> UpdateAsync(BlogInPost EditablePost)
        {
            var postToEdit = await blogDbContext.BlogPosts.Include(nameof(BlogInPost.Tags))
                .FirstOrDefaultAsync(x => x.Id == EditablePost.Id);


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
                // Delete the existing tags then add new ones
                if (EditablePost.Tags != null && EditablePost.Tags.Any())
                {
                    blogDbContext.Tags.RemoveRange(postToEdit.Tags);
                    //adding
                    EditablePost.Tags.ToList().ForEach(x => x.BlogInPostId = postToEdit.Id);
                    await blogDbContext.Tags.AddRangeAsync(EditablePost.Tags);
                    Console.WriteLine(EditablePost.Id);
                }
                //postToEdit.Tags = EditablePost.Tags;
            }

            await blogDbContext.SaveChangesAsync();
            return postToEdit;
        }

    }
}
