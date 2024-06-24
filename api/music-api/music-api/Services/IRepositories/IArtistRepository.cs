using music_api.DTOs;
using music_api.Models;

namespace music_api.Services.IRepositories
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetAllArtists();
        Task<List<Artist>> GetArtistById(long id);
        Task<Artist> AddArtist(AlbumDTO albumDTO);
        Task<Artist> DeleteArtist(long id);
        Task<Artist> UpdateArtist(long id,ArtistDTO artistDTO);
    }
}
