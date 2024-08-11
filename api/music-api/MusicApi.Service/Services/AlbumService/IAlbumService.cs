using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;

namespace MusicApi.Infracstructure.Services.AlbumService
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAllAlbums();
        Task<IEnumerable<Album>> GetAllAlbumWithPaged(int? page, int? pageSize);
        Task<Album> GetAlbumById(Guid id);
        Task<Album> CreatAlbum(AlbumDTO albumDTO);
        Task<Album> DeleteAlbum(Guid id);
        Task<Album> UpdateAlbum(Guid id, AlbumDTO album);
        Task<IEnumerable<SongResponse>> GetAllSongOfAlbum(Guid id);
        Task AddSongToAlbum(Guid idAlbum, Guid idSong);

        Task<bool> IsExist(Guid idAlbum);

    }
}
