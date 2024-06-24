using music_api.DTOs;
using music_api.Models;

namespace music_api.Services.IRepositories
{
    public interface IPlayListRepository
    {
        Task<List<Artist>> GetPlayListsOfUser(long userId);
        Task<List<Artist>> GetPlayListById(long id);
        Task<Artist> AddPlayList(PlayListDTO playListDTO,long userId);
        Task<PlayList> DeletePlayList(long id);
        Task<PlayList> UpdateArtist(long id, PlayListDTO playListDTO);
        Task AddSongToPlayList(SongDTO songDTO, long id);

    }
}
