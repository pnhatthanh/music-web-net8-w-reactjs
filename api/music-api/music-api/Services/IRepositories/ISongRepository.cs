using music_api.DTOs;
using music_api.Models;

namespace music_api.Services.IRepositories
{
    public interface ISongRepository
    {
        Task<List<Song>> GetAllSongs();
        Task<Song> GetSongById(Guid id);
        Task<Song> CreatSong(SongDTO songDTO);
        Task<Song> DeleteSong(Guid id);
        Task<Song> UpdateSong(Guid id, SongDTO song);
    }
}
