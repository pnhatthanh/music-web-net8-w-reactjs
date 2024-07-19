using MusicApi.Data.DTOs;
using MusicApi.Data.Models;

namespace MusicApi.Infracstructure.Services.ArtistService
{
    public interface IArtistService
    {
        Task<List<Artist>> GetAllArtists();
        Task<Artist> GetArtistById(Guid id);
        Task<Artist> AddArtist(ArtistDTO artistDTO);
        Task<Artist> DeleteArtist(Guid id);
        Task<Artist> UpdateArtist(Guid id, ArtistDTO artistDTO);
    }
}
