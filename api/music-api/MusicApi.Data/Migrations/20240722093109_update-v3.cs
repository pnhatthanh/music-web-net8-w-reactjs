using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSong",
                table: "playlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSong",
                table: "albums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSong",
                table: "playlists");

            migrationBuilder.DropColumn(
                name: "NumberOfSong",
                table: "albums");
        }
    }
}
