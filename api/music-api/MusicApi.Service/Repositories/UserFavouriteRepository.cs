using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.Models;
using MusicApi.Infracstructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Repositories
{
    public class UserFavouriteRepository(ApplicationDbContext context)
        : BaseRepository<UserFavourite>(context), IUserFavouriteRepository
    {
        public async Task<IEnumerable<Song?>> GetSongs(Guid userId, int page, int pageSize)
        {
            var songs=await _dbSet.Include(u=>u.Song).ThenInclude(s=>s!.artist)
                .Where(u=>u.UserId== userId).OrderByDescending(u=>u.CreatedAt)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .Select(u=>u.Song).ToListAsync();
            return songs;
        }
        public async Task<int> QuantityFavouriteSong(Guid userId)
        {
            return await _dbSet.Where(u=>u.UserId==userId).CountAsync();
        }
        public async Task<bool> IsSongFavourite(Guid? userId, Guid songId)
        {
            return await _dbSet.AnyAsync(u => u.UserId == userId && u.SongId == songId);
        }
    }
}
