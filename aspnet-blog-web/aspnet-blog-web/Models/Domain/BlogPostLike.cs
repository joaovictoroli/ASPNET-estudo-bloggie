namespace aspnet_blog_web.Models.Domain
{
    public class BlogPostLike
    {
        public Guid Id { get; set; }
        public Guid BlogInPostId { get; set; }
        public Guid UserId { get; set; }

    }
}
