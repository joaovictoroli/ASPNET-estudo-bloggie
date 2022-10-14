using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnet_blog_web.Migrations
{
    public partial class Fixingnavigationproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_BlogPosts_BlogInPostId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "Tags");

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogInPostId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_BlogPosts_BlogInPostId",
                table: "Tags",
                column: "BlogInPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_BlogPosts_BlogInPostId",
                table: "Tags");

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogInPostId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "BlogPostId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_BlogPosts_BlogInPostId",
                table: "Tags",
                column: "BlogInPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id");
        }
    }
}
