using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnet_blog_web.Migrations
{
    public partial class Fixingtabblecomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayAddes",
                table: "BlogPostComment",
                newName: "DateAdded");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "BlogPostComment",
                newName: "DayAddes");
        }
    }
}
