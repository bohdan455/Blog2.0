using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnOfLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Articles_BlogId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Likes",
                newName: "ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_BlogId",
                table: "Likes",
                newName: "IX_Likes_ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Articles_ArticleId",
                table: "Likes",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Articles_ArticleId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Likes",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_ArticleId",
                table: "Likes",
                newName: "IX_Likes_BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Articles_BlogId",
                table: "Likes",
                column: "BlogId",
                principalTable: "Articles",
                principalColumn: "Id");
        }
    }
}
