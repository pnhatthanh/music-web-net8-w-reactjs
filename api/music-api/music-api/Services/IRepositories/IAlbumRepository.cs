using music_api.DTOs;
using music_api.Models;

namespace music_api.Services.IRepositories
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAllAlbums();
        Task<Album> GetAlbumById(long id);
        Task<Album> CreatAlbum(AlbumDTO albumDTO);
        Task<Album> DeleteAlbum(long id);
        Task<Album> UpdateAlbum(Guid id,AlbumDTO album);
        Task AddSongToAlbum(Guid songId, Album album);

    }
}
