using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnet_blog_web.Migrations.AuthDb
{
    public partial class AddingNormalizedusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ec57198-ae21-472c-972b-98f1da6c17df",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "611301c2-5e3f-4962-bc34-9600a0c92fd5", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAEAACcQAAAAEK6XTTpjP0dNf2QBnAaOKJ1COo4l7OGC0LpSrV01A1YTJ4sECWdzs1pCV+/TcmkeYQ==", "5dfd4432-c001-4cb6-96ff-9ed4c442734c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ec57198-ae21-472c-972b-98f1da6c17df",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b88b13a9-6564-4513-b411-08bd97dbd807", null, null, "AQAAAAEAACcQAAAAEOBknuXy/2Uijo4n89JVmCWUp6VEpTgw7qZqSjqAQ1bekT5W5UWKi7cIZN9CCPbwwQ==", "0c61e891-143f-4e77-b29c-9655e29e099e" });
        }
    }
}
