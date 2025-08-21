using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMApi.Migrations
{
    /// <inheritdoc />
    public partial class dobchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_SMUser_sMUsersuserId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_SMUser_sMUsersuserId",
                table: "Post");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerDate",
                table: "SMUser",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "SMUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "sMUsersuserId",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "targetType",
                table: "Like",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "sMUsersuserId",
                table: "Like",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "commentText",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_SMUser_sMUsersuserId",
                table: "Like",
                column: "sMUsersuserId",
                principalTable: "SMUser",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_SMUser_sMUsersuserId",
                table: "Post",
                column: "sMUsersuserId",
                principalTable: "SMUser",
                principalColumn: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_SMUser_sMUsersuserId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_SMUser_sMUsersuserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "age",
                table: "SMUser");

            migrationBuilder.AlterColumn<string>(
                name: "registerDate",
                table: "SMUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "sMUsersuserId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "targetType",
                table: "Like",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "sMUsersuserId",
                table: "Like",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "commentText",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_SMUser_sMUsersuserId",
                table: "Like",
                column: "sMUsersuserId",
                principalTable: "SMUser",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_SMUser_sMUsersuserId",
                table: "Post",
                column: "sMUsersuserId",
                principalTable: "SMUser",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
