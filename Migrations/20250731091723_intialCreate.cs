using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMApi.Migrations
{
    /// <inheritdoc />
    public partial class intialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMUser",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    registerDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMUser", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    likeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    targetId = table.Column<int>(type: "int", nullable: false),
                    targetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    sMUsersuserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.likeId);
                    table.ForeignKey(
                        name: "FK_Like_SMUser_sMUsersuserId",
                        column: x => x.sMUsersuserId,
                        principalTable: "SMUser",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    postId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    sMUsersuserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.postId);
                    table.ForeignKey(
                        name: "FK_Post_SMUser_sMUsersuserId",
                        column: x => x.sMUsersuserId,
                        principalTable: "SMUser",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSecurity",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecurity", x => x.userId);
                    table.ForeignKey(
                        name: "FK_UserSecurity_SMUser_userId",
                        column: x => x.userId,
                        principalTable: "SMUser",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    commentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    postId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.commentId);
                    table.ForeignKey(
                        name: "FK_Comment_Post_postId",
                        column: x => x.postId,
                        principalTable: "Post",
                        principalColumn: "postId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_SMUser_userId",
                        column: x => x.userId,
                        principalTable: "SMUser",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_postId",
                table: "Comment",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_userId",
                table: "Comment",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_sMUsersuserId",
                table: "Like",
                column: "sMUsersuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_sMUsersuserId",
                table: "Post",
                column: "sMUsersuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "UserSecurity");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "SMUser");
        }
    }
}
