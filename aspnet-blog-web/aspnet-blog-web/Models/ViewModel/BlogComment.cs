using System.ComponentModel.DataAnnotations;

namespace aspnet_blog_web.Models.ViewModel
{
    public class BlogComment
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
