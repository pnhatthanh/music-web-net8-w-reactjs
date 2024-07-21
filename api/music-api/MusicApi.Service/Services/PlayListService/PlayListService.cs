using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public readonly IMapper _mapper;
        public PlayListService(ApplicationDbContext context, IMapper mapper)
        {
            _playListRepository = new PlayListRepository(context);
            _mapper = mapper;
        }
        public async Task<PlayList> AddPlayList(PlayListDTO playListDTO, Guid userId)
        {
            var user= await _context.users.Include(u=>u.PlayLists).FirstOrDefaultAsync(u=>u.UserId==userId);
            if (user==null)
            {
                throw new Exception("User not found");
            }
            PlayList playList=_mapper.Map<PlayList>(playListDTO);
            user.PlayLists.Add(playList);
            await _context.SaveChangesAsync();
            return playList;
        }

        public async Task AddSongToPlayList(Guid idPlayList, Guid idSong)
        {
            var song =await _context.songs.FindAsync(idSong);
            if (song==null)
            {
                throw new ArgumentException("Song not found");
            }
            var playList = await _context.playlists.Include(p => p.Songs)
                .FirstOrDefaultAsync(p => p.PlayListId == idPlayList);
            if (playList == null)
            {
                throw new ArgumentException("Playlist not found");
            }
            playList.Songs.Add(song);
            await _context.SaveChangesAsync();
        }

        public async Task<PlayList> DeletePlayList(Guid id)
        {
            var playList = await _context.playlists.FindAsync(id);
            if (playList==null)
            {
                throw new Exception("Playlist not found");
            }
            _context.playlists.Remove(playList);
            await _context.SaveChangesAsync();
            return playList;
        }

        public async Task<PlayList> GetPlayListById(Guid id)
        {
            var playList= await _context.playlists.Include(p=>p.Songs).FirstOrDefaultAsync(p=>p.PlayListId==id);
            if (playList == null)
            {
                throw new ArgumentException("Playlist not found");
            }
            return playList;
        }

        public async Task<List<PlayList>> GetPlayListsOfUser(Guid userId)
        {
            return await _context.playlists.Where(p=>p.UserId==userId).ToListAsync();
        }

        public async Task<PlayList> UpdatePlayList(Guid id, PlayListDTO playListDTO)
        {
            var playList = await GetPlayListById(id);
            _mapper.Map(playListDTO, playList);
            await _context.SaveChangesAsync();
            return playList;
        }

        public async Task RemoveSongFromPlayList(Guid idPlayList, Guid idSong)
        {
            var song = await _context.songs.FindAsync(idSong);
            if (song == null)
            {
                throw new ArgumentException("Song not found");
            }
            var playList = await _context.playlists.Include(p => p.Songs)
                .FirstOrDefaultAsync(p => p.PlayListId == idPlayList);
            if (playList == null)
            {
                throw new ArgumentException("Playlist not found");
            }
            playList.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }
    }
}
