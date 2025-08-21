using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMApi.Migrations
{
    /// <inheritdoc />
    public partial class _DeleteAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_SMUser_sMUsersuserId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Post_sMUsersuserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "sMUsersuserId",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "SMUser",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "LikeComments",
                columns: table => new
                {
                    commentId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    likeCommentId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeComments", x => new { x.userId, x.commentId });
                    table.ForeignKey(
                        name: "FK_LikeComments_Comment_commentId",
                        column: x => x.commentId,
                        principalTable: "Comment",
                        principalColumn: "commentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeComments_SMUser_userId",
                        column: x => x.userId,
                        principalTable: "SMUser",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikePosts",
                columns: table => new
                {
                    postId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    likePostId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikePosts", x => new { x.userId, x.postId });
                    table.ForeignKey(
                        name: "FK_LikePosts_Post_postId",
                        column: x => x.postId,
                        principalTable: "Post",
                        principalColumn: "postId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikePosts_SMUser_userId",
                        column: x => x.userId,
                        principalTable: "SMUser",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMUser_email",
                table: "SMUser",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_userId",
                table: "Post",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComments_commentId",
                table: "LikeComments",
                column: "commentId");

            migrationBuilder.CreateIndex(
                name: "IX_LikePosts_postId",
                table: "LikePosts",
                column: "postId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_SMUser_userId",
                table: "Post",
                column: "userId",
                principalTable: "SMUser",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_SMUser_userId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "LikeComments");

            migrationBuilder.DropTable(
                name: "LikePosts");

            migrationBuilder.DropIndex(
                name: "IX_SMUser_email",
                table: "SMUser");

            migrationBuilder.DropIndex(
                name: "IX_Post_userId",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "SMUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "sMUsersuserId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    likeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sMUsersuserId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    targetId = table.Column<int>(type: "int", nullable: false),
                    targetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.likeId);
                    table.ForeignKey(
                        name: "FK_Like_SMUser_sMUsersuserId",
                        column: x => x.sMUsersuserId,
                        principalTable: "SMUser",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_sMUsersuserId",
                table: "Post",
                column: "sMUsersuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_sMUsersuserId",
                table: "Like",
                column: "sMUsersuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_SMUser_sMUsersuserId",
                table: "Post",
                column: "sMUsersuserId",
                principalTable: "SMUser",
                principalColumn: "userId");
        }
    }
}
