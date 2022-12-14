using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace aspnet_blog_web.Models.ViewModel
{
    public class Register
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]        
        public string Password { get; set; }
    }
}
