using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMApi.Migrations
{
    /// <inheritdoc />
    public partial class _FinalDeleteAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_postId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComments_SMUser_userId",
                table: "LikeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikePosts_SMUser_userId",
                table: "LikePosts");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_postId",
                table: "Comment",
                column: "postId",
                principalTable: "Post",
                principalColumn: "postId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComments_SMUser_userId",
                table: "LikeComments",
                column: "userId",
                principalTable: "SMUser",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikePosts_SMUser_userId",
                table: "LikePosts",
                column: "userId",
                principalTable: "SMUser",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_postId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComments_SMUser_userId",
                table: "LikeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikePosts_SMUser_userId",
                table: "LikePosts");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_postId",
                table: "Comment",
                column: "postId",
                principalTable: "Post",
                principalColumn: "postId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComments_SMUser_userId",
                table: "LikeComments",
                column: "userId",
                principalTable: "SMUser",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikePosts_SMUser_userId",
                table: "LikePosts",
                column: "userId",
                principalTable: "SMUser",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
