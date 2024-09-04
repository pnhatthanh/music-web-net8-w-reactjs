using MusicApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Repositories.IRepository
{
    public interface IUserFavouriteRepository : IBaseRepository<UserFavourite>
    {
        Task<IEnumerable<Song?>> GetSongs(Guid userId, int page, int pageSize);
        Task<bool> IsSongFavourite(Guid? userId, Guid songId);
        Task<int> QuantityFavouriteSong(Guid userId);
    }
}
