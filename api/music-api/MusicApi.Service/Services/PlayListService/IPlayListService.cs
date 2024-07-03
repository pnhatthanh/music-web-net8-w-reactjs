using MusicApi.Data.DTOs;
using MusicApi.Data.Models;

namespace MusicApi.Service.Services.PlayListService
{
    public interface IPlayListService
    {
        Task<List<PlayList>> GetPlayListsOfUser(Guid userId);
        Task<PlayList> GetPlayListById(Guid id);
        Task<PlayList> AddPlayList(PlayListDTO playListDTO, Guid userId);
        Task<PlayList> DeletePlayList(Guid id);
        Task<PlayList> UpdatePlayList(Guid id, PlayListDTO playListDTO);
        Task AddSongToPlayList(Guid idPlayList, Guid idSong);

        Task RemoveSongFromPlayList(Guid idPlayList, Guid idSong);

    }
}
