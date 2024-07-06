using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Models;

namespace MusicApi.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Album> albums { get; set; }
        public DbSet<Artist> artists { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<PlayList> playlists { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Song> songs { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Token> tokens { get; set; } 
    }
}
