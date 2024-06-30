using MusicApi.Data.DTOs;
using MusicApi.Data.Models;

namespace MusicApi.Service.Services.AlbumService
{
    public interface IAlbumService
    {
        Task<List<Album>> GetAllAlbums();
        Task<Album> GetAlbumById(long id);
        Task<Album> CreatAlbum(AlbumDTO albumDTO);
        Task<Album> DeleteAlbum(long id);
        Task<Album> UpdateAlbum(Guid id, AlbumDTO album);
        Task AddSongToAlbum(Guid songId, Album album);

    }
}
