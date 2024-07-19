using MusicApi.Data.DTOs;
using MusicApi.Data.Models;

namespace MusicApi.Infracstructure.Services.SongService
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetAllSongs();
        Task<Song> GetSongById(Guid id);
        Task<Song> CreatSong(SongDTO songDTO);
        Task<Song> DeleteSong(Guid id);
        Task<Song> UpdateSong(Guid id, SongDTO song);
    }
}
