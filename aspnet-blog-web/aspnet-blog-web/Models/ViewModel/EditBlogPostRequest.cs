using System.ComponentModel.DataAnnotations;

namespace aspnet_blog_web.Models.ViewModel
{
    public class EditBlogPostRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Heading { get; set; }
        [Required]
        public string? PageTitle { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public string? ShortDescription { get; set; }
        [Required]
        public string? FeaturedImageUrl { get; set; }
        [Required]
        public string? UrlHandle { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public bool Visible { get; set; }
    }
}
