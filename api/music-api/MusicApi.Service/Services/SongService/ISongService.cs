using CloudinaryDotNet.Actions;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;

namespace MusicApi.Infracstructure.Services.SongService
{
    public interface ISongService
    {
        Task<IEnumerable<SongResponse>> GetAllSongs(int page, int pageSize);
        Task<Song> GetSongById(Guid id);
        Task<Song> CreatSong(SongDTO songDTO);
        Task<Song> DeleteSong(Guid id);
        Task<Song> UpdateSong(Guid id, SongDTO song);
    }
}
