using MusicApi.Data.DTOs;
using MusicApi.Data.Models;

namespace MusicApi.Service.Services.SongService
{
    public interface ISongService
    {
        Task<List<Song>> GetAllSongs();
        Task<Song> GetSongById(Guid id);
        Task<Song> CreatSong(SongDTO songDTO);
        Task<Song> DeleteSong(Guid id);
        Task<Song> UpdateSong(Guid id, SongDTO song);
    }
}
