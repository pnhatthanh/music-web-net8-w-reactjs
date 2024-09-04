using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;

namespace MusicApi.Infracstructure.Services.UserService
{
    public interface IUserService
    {
        Task CreateAccount(RegisterDTO registerDTO);
        Task<Song> AddSongToFavourites(Guid idSong, Guid userId);
        Task<PaginatedData> GetFavouriteSongs(Guid userId, int page, int pageSize);
        Task RemoveSongFromFavourite(Guid idSong, Guid userId);
    }
}
