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
        public async Task<IEnumerable<Song?>> GetSongs(Guid userId)
        {
            var songs=await _dbSet.Include(u=>u.Song).ThenInclude(s=>s!.artist)
                .Where(u=>u.UserId== userId).Select(u=>u.Song).ToListAsync();
            return songs;
        }
    }
}
