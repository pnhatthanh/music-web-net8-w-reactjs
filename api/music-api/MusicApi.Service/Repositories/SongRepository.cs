using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.Models;
using MusicApi.Infracstructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Repositories
{
    public class SongRepository(ApplicationDbContext context) 
        : BaseRepository<Song>(context),ISongRepository
    {
        public new async Task<IEnumerable<Song>> GetAllPaged(int? page, int? pageSize, params Expression<Func<Song, object>>[] includes)
        {
            var query = _dbSet.AsQueryable().ApplyIncludes(includes).OrderByDescending(s=>s.ListenCount);
            if (page.HasValue && pageSize.HasValue)
            {
                return await query .Skip((page.Value - 1) * pageSize.Value)
                                   .Take(pageSize.Value)
                                   .ToListAsync();
            }
            return await query.ToListAsync();
        }
    }
}
