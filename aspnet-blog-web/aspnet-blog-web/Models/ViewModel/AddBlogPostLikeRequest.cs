namespace aspnet_blog_web.Models.ViewModel
{
    public class AddBlogPostLikeRequest
    {
        public Guid BlogInPostId { get; set; }

        public Guid UserId { get; set; }
    }
}
