using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumSong_albums_AlbumsAlbumId",
                table: "AlbumSong");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumSong_songs_SongsSongId",
                table: "AlbumSong");

            migrationBuilder.DropTable(
                name: "SongUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumSong",
                table: "AlbumSong");

            migrationBuilder.RenameTable(
                name: "AlbumSong",
                newName: "albumSong");

            migrationBuilder.RenameColumn(
                name: "SongsSongId",
                table: "albumSong",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "AlbumsAlbumId",
                table: "albumSong",
                newName: "AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumSong_SongsSongId",
                table: "albumSong",
                newName: "IX_albumSong_SongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_albumSong",
                table: "albumSong",
                columns: new[] { "AlbumId", "SongId" });

            migrationBuilder.CreateTable(
                name: "userFavourites",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userFavourites", x => new { x.UserId, x.SongId });
                    table.ForeignKey(
                        name: "FK_userFavourites_songs_SongId",
                        column: x => x.SongId,
                        principalTable: "songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userFavourites_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userFavourites_SongId",
                table: "userFavourites",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_albumSong_albums_AlbumId",
                table: "albumSong",
                column: "AlbumId",
                principalTable: "albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_albumSong_songs_SongId",
                table: "albumSong",
                column: "SongId",
                principalTable: "songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albumSong_albums_AlbumId",
                table: "albumSong");

            migrationBuilder.DropForeignKey(
                name: "FK_albumSong_songs_SongId",
                table: "albumSong");

            migrationBuilder.DropTable(
                name: "userFavourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_albumSong",
                table: "albumSong");

            migrationBuilder.RenameTable(
                name: "albumSong",
                newName: "AlbumSong");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "AlbumSong",
                newName: "SongsSongId");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "AlbumSong",
                newName: "AlbumsAlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_albumSong_SongId",
                table: "AlbumSong",
                newName: "IX_AlbumSong_SongsSongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumSong",
                table: "AlbumSong",
                columns: new[] { "AlbumsAlbumId", "SongsSongId" });

            migrationBuilder.CreateTable(
                name: "SongUser",
                columns: table => new
                {
                    SongsSongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongUser", x => new { x.SongsSongId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_SongUser_songs_SongsSongId",
                        column: x => x.SongsSongId,
                        principalTable: "songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongUser_users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongUser_UsersUserId",
                table: "SongUser",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumSong_albums_AlbumsAlbumId",
                table: "AlbumSong",
                column: "AlbumsAlbumId",
                principalTable: "albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumSong_songs_SongsSongId",
                table: "AlbumSong",
                column: "SongsSongId",
                principalTable: "songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
