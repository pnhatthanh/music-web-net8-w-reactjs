using MusicApi.Data.DTOs;
using MusicApi.Data.Models;

namespace MusicApi.Service.Services.UserService
{
    public interface IUserService
    {
        Task<UserDTO> CreateAccount(RegisterDTO registerDTO);
        Task<Song> AddSongToFavourites(Guid idSong, Guid userId);
        Task<List<Song>> GetFavouriteSongs(Guid userId);
        Task RemoveSongFromFavourite(Guid idSong, Guid userId);
    }
}
