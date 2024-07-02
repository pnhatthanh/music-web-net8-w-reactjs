using MusicApi.Data.DTOs;
using MusicApi.Data.Models;

namespace MusicApi.Service.Services.AlbumService
{
    public interface IAlbumService
    {
        Task<List<Album>> GetAllAlbums();
        Task<Album> GetAlbumById(Guid id);
        Task<Album> CreatAlbum(AlbumDTO albumDTO);
        Task<Album> DeleteAlbum(Guid id);
        Task<Album> UpdateAlbum(Guid id, AlbumDTO album);
        Task AddSongToAlbum(Guid idAlbum, Guid idSong);

    }
}
