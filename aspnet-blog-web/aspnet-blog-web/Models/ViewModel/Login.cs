using System.ComponentModel.DataAnnotations;

namespace aspnet_blog_web.Models.ViewModel
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
