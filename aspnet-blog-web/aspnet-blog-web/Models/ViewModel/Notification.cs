using aspnet_blog_web.Enums;
using Microsoft.Data.SqlClient;

namespace aspnet_blog_web.Models.ViewModel
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }

    }
}
