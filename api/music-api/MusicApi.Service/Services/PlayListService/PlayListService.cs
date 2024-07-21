using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Infracstructure.Repositories;
using MusicApi.Infracstructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Services.PlayListService
{
    public class PlayListService : IPlayListService
    {
        private readonly IPlayListRepository _playListRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISongRepository _songRepository;
        public readonly IMapper _mapper;
        public PlayListService(ApplicationDbContext context, IMapper mapper)
        {
            _playListRepository = new PlayListRepository(context);
            _userRepository = new UserRepository(context);
            _songRepository = new SongRepository(context);   
            _mapper = mapper;
        }
        public async Task<PlayList> AddPlayList(PlayListDTO playListDTO, Guid userId)
        {
            var user= await _userRepository.GetByIdAsynch(userId)
                    ?? throw new Exception("User not found");
            PlayList playList =_mapper.Map<PlayList>(playListDTO);
            playList.UserId = userId;
            await _playListRepository.AddAsynch(playList);
            return playList;
        }

        public async Task AddSongToPlayList(Guid idPlayList, Guid idSong)
        {
            var song = await _songRepository.GetByIdAsynch(idSong)
                ?? throw new Exception("Song not found");
            var playList = await _playListRepository
                .FirstOrDefaultWithIncludes(p => p.PlayListId == idPlayList, p => p.Songs)
                ?? throw new Exception("Playlist not found");
            if(playList.Songs.Contains(song))
            {
                throw new Exception("Song already added to playlist");
            }
            playList.Songs.Add(song);
            await _playListRepository.UpdateAsynch(playList);
        }

        public async Task<PlayList> DeletePlayList(Guid id)
        {
            var playList = await _playListRepository.GetByIdAsynch(id)
                ?? throw new Exception("Playlist not found");
            await _playListRepository.Delete(playList);
            return playList;
        }

        public async Task GetSongs(Guid playlistId)
        {

        }

        public async Task<PlayList> GetPlayListById(Guid id)
        {
            var playList = await _playListRepository.GetByIdAsynch(id)
                ?? throw new Exception("Playlist not found");
            return playList;
        }

        public async Task<IEnumerable<PlayList>> GetPlayListsOfUser(Guid userId)
        {
            return await _playListRepository.GetMany(p=>p.UserId==userId);
        }

        public async Task<PlayList> UpdatePlayList(Guid id, PlayListDTO playListDTO)
        {
            var playList = await _playListRepository.GetByIdAsynch(id)
                ?? throw new Exception("Playlist not found");
            _mapper.Map(playListDTO, playList);
            await _playListRepository.UpdateAsynch(playList);
            return playList;
        }

        public async Task RemoveSongFromPlayList(Guid idPlayList, Guid idSong)
        {
            var song = await _songRepository.GetByIdAsynch(idSong)
                ?? throw new Exception("Song not found");
            var playList = await _playListRepository
                .FirstOrDefaultWithIncludes(p => p.PlayListId == idPlayList, p => p.Songs)
                ?? throw new Exception("Playlist not found");
            playList.Songs.Remove(song);
            await _playListRepository.UpdateAsynch(playList);
        }
    }
}
