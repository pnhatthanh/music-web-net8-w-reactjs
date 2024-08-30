using CloudinaryDotNet.Actions;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;

namespace MusicApi.Infracstructure.Services.SongService
{
    public interface ISongService
    {
        Task<IEnumerable<SongResponse>> GetAllSongs(int? page, int? pageSize);
        Task<IEnumerable<SongResponse>> GetRecentLyPlay(Guid[] idSongs);
        Task<SongResponse> GetSongById(Guid id, Guid? userId=null);
        Task<Song> CreatSong(SongDTO songDTO);
        Task<Song> DeleteSong(Guid id);
        Task<Song> UpdateSong(Guid id, SongDTO song);
        public Task<IEnumerable<SongResponse>> GetSongByTitle(string title);
    }
}
