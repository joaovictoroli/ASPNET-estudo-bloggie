using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnet_blog_web.Migrations
{
    public partial class AddingTableforBlostPostLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPostLike",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogInPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostLike_BlogPosts_BlogInPostId",
                        column: x => x.BlogInPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostLike_BlogInPostId",
                table: "BlogPostLike",
                column: "BlogInPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostLike");
        }
    }
}
