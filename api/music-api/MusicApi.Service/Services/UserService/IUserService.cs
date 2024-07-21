using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;

namespace MusicApi.Infracstructure.Services.UserService
{
    public interface IUserService
    {
        Task CreateAccount(RegisterDTO registerDTO);
        Task<Song> AddSongToFavourites(Guid idSong, Guid userId);
        Task<IEnumerable<SongResponse>> GetFavouriteSongs(Guid userId);
        Task RemoveSongFromFavourite(Guid idSong, Guid userId);
    }
}
