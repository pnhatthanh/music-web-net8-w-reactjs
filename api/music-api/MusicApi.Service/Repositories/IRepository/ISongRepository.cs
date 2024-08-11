using MusicApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Repositories.IRepository
{
     public interface ISongRepository : IBaseRepository<Song>
    {
        public new Task<IEnumerable<Song>> GetAllPaged(int? page, int? pageSize, params Expression<Func<Song, object>>[] includes);
    }
}
