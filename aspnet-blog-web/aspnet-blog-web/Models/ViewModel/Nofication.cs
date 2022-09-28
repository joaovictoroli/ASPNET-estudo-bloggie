using Microsoft.Data.SqlClient;

namespace aspnet_blog_web.Models.ViewModel
{
    public class Nofication
    {
        public string Message { get; set; }

        public SqlNotificationType Type { get; set; }

    }
}
