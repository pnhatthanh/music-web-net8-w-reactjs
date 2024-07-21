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
    internal class PlayListRepository(ApplicationDbContext context) 
        : BaseRepository<PlayList>(context), IPlayListRepository
    {
        public async Task<IEnumerable<Song>> GetSong(Guid playlistId)
        {
            var songs =await _dbSet.Where(p => p.PlayListId == playlistId)
                        .SelectMany(p => p.Songs).Include(s => s.artist).ToListAsync();
            return songs;
        }
    }
}
