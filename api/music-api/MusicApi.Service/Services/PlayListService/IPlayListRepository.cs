using MusicApi.Data.DTOs;
using MusicApi.Data.Models;

namespace MusicApi.Service.Services.PlayListService
{
    public interface IPlayListRepository
    {
        Task<List<Artist>> GetPlayListsOfUser(long userId);
        Task<List<Artist>> GetPlayListById(long id);
        Task<Artist> AddPlayList(PlayListDTO playListDTO, long userId);
        Task<PlayList> DeletePlayList(long id);
        Task<PlayList> UpdateArtist(long id, PlayListDTO playListDTO);
        Task AddSongToPlayList(SongDTO songDTO, long id);

    }
}
