namespace aspnet_blog_web.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BlogInPostId { get; set; }
    }
}
