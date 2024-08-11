using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;

namespace MusicApi.Infracstructure.Services.ArtistService
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistResponse>> GetAllArtists();
        Task<IEnumerable<ArtistResponse>> GetAllArtistsWithPaged(int? page, int? pageSize);
        Task<IEnumerable<SongResponse>> GetAllSongs(int page, int pageSize, Guid id);
        Task<IEnumerable<ArtistResponse>> GetArtistByName(string name);
        Task<Artist> GetArtistById(Guid id);
        Task<Artist> AddArtist(ArtistDTO artistDTO);
        Task<Artist> DeleteArtist(Guid id);
        Task<Artist> UpdateArtist(Guid id, ArtistDTO artistDTO);
    }
}
