using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMApi.Migrations
{
    /// <inheritdoc />
    public partial class likeCommentsandLikePosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments");

            migrationBuilder.AlterColumn<int>(
                name: "likePostId",
                table: "LikePosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "likeCommentId",
                table: "LikeComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts",
                column: "likePostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments",
                column: "likeCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_LikePosts_userId",
                table: "LikePosts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComments_userId",
                table: "LikeComments",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts");

            migrationBuilder.DropIndex(
                name: "IX_LikePosts_userId",
                table: "LikePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments");

            migrationBuilder.DropIndex(
                name: "IX_LikeComments_userId",
                table: "LikeComments");

            migrationBuilder.AlterColumn<int>(
                name: "likePostId",
                table: "LikePosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "likeCommentId",
                table: "LikeComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts",
                columns: new[] { "userId", "postId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments",
                columns: new[] { "userId", "commentId" });
        }
    }
}
