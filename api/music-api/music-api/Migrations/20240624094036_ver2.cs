using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace music_api.Migrations
{
    /// <inheritdoc />
    public partial class ver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayListSong_playlists_PlayListId",
                table: "PlayListSong");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayListSong_songs_SongId",
                table: "PlayListSong");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_albums_AlbumId",
                table: "songs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongUser_songs_SongId",
                table: "SongUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SongUser_users_UserId",
                table: "SongUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongUser",
                table: "SongUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayListSong",
                table: "PlayListSong");

            migrationBuilder.DropIndex(
                name: "IX_PlayListSong_SongId",
                table: "PlayListSong");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "SongUser");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "PlayListSong");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SongUser",
                newName: "UsersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SongUser_UserId",
                table: "SongUser",
                newName: "IX_SongUser_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "ListenCount",
                table: "songs",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "PlayListId",
                table: "PlayListSong",
                newName: "PlayListsPlayListId");

            migrationBuilder.AddColumn<Guid>(
                name: "SongsSongId",
                table: "SongUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "songs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SongId",
                table: "songs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "SongLyrics",
                table: "songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SongsSongId",
                table: "PlayListSong",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "albums",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongUser",
                table: "SongUser",
                columns: new[] { "SongsSongId", "UsersUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayListSong",
                table: "PlayListSong",
                columns: new[] { "PlayListsPlayListId", "SongsSongId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayListSong_SongsSongId",
                table: "PlayListSong",
                column: "SongsSongId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListSong_playlists_PlayListsPlayListId",
                table: "PlayListSong",
                column: "PlayListsPlayListId",
                principalTable: "playlists",
                principalColumn: "PlayListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListSong_songs_SongsSongId",
                table: "PlayListSong",
                column: "SongsSongId",
                principalTable: "songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_albums_AlbumId",
                table: "songs",
                column: "AlbumId",
                principalTable: "albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongUser_songs_SongsSongId",
                table: "SongUser",
                column: "SongsSongId",
                principalTable: "songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongUser_users_UsersUserId",
                table: "SongUser",
                column: "UsersUserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayListSong_playlists_PlayListsPlayListId",
                table: "PlayListSong");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayListSong_songs_SongsSongId",
                table: "PlayListSong");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_albums_AlbumId",
                table: "songs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongUser_songs_SongsSongId",
                table: "SongUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SongUser_users_UsersUserId",
                table: "SongUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongUser",
                table: "SongUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayListSong",
                table: "PlayListSong");

            migrationBuilder.DropIndex(
                name: "IX_PlayListSong_SongsSongId",
                table: "PlayListSong");

            migrationBuilder.DropColumn(
                name: "SongsSongId",
                table: "SongUser");

            migrationBuilder.DropColumn(
                name: "SongLyrics",
                table: "songs");

            migrationBuilder.DropColumn(
                name: "SongsSongId",
                table: "PlayListSong");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "albums");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "SongUser",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SongUser_UsersUserId",
                table: "SongUser",
                newName: "IX_SongUser_UserId");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "songs",
                newName: "ListenCount");

            migrationBuilder.RenameColumn(
                name: "PlayListsPlayListId",
                table: "PlayListSong",
                newName: "PlayListId");

            migrationBuilder.AddColumn<long>(
                name: "SongId",
                table: "SongUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "AlbumId",
                table: "songs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<long>(
                name: "SongId",
                table: "songs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "SongId",
                table: "PlayListSong",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "AlbumId",
                table: "albums",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongUser",
                table: "SongUser",
                columns: new[] { "SongId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayListSong",
                table: "PlayListSong",
                columns: new[] { "PlayListId", "SongId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayListSong_SongId",
                table: "PlayListSong",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListSong_playlists_PlayListId",
                table: "PlayListSong",
                column: "PlayListId",
                principalTable: "playlists",
                principalColumn: "PlayListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListSong_songs_SongId",
                table: "PlayListSong",
                column: "SongId",
                principalTable: "songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_albums_AlbumId",
                table: "songs",
                column: "AlbumId",
                principalTable: "albums",
                principalColumn: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_SongUser_songs_SongId",
                table: "SongUser",
                column: "SongId",
                principalTable: "songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongUser_users_UserId",
                table: "SongUser",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
