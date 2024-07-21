using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;

namespace MusicApi.Infracstructure.Services.PlayListService
{
    public interface IPlayListService
    {
        Task<IEnumerable<PlayList>> GetPlayListsOfUser(Guid userId);
        Task<PlayList> GetPlayListById(Guid id);
        Task<PlayList> AddPlayList(PlayListDTO playListDTO, Guid userId);
        Task<PlayList> DeletePlayList(Guid id);
        Task<PlayList> UpdatePlayList(Guid id, PlayListDTO playListDTO);
        Task<IEnumerable<SongResponse>> GetSongs(Guid playlistId);
        Task AddSongToPlayList(Guid idPlayList, Guid idSong);
        Task RemoveSongFromPlayList(Guid idPlayList, Guid idSong);
        public Task<bool> IsExist(Guid playlistId);

    }
}
