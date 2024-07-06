using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class tokenchg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_users_userId",
                table: "Token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.RenameTable(
                name: "Token",
                newName: "tokens");

            migrationBuilder.RenameIndex(
                name: "IX_Token_userId",
                table: "tokens",
                newName: "IX_tokens_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tokens",
                table: "tokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tokens_users_userId",
                table: "tokens",
                column: "userId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tokens_users_userId",
                table: "tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tokens",
                table: "tokens");

            migrationBuilder.RenameTable(
                name: "tokens",
                newName: "Token");

            migrationBuilder.RenameIndex(
                name: "IX_tokens_userId",
                table: "Token",
                newName: "IX_Token_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Token_users_userId",
                table: "Token",
                column: "userId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
