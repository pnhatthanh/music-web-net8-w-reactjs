using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Helper.Helpers;

namespace MusicApi.Service.Services.SongService
{
    public class SongService : ISongService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly FileHelper _fileHelper;
        public SongService(ApplicationDbContext context,
            FileHelper fileHelper,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _fileHelper = fileHelper;
        }
        public async Task<Song> CreatSong(SongDTO songDTO)
        {
            Song song = _mapper.Map<Song>(songDTO);
            song.SongImagePath = await _fileHelper.UploadFileImage(songDTO.ImageFile);
            song.SongPath = await _fileHelper.UploadFileAudio(songDTO.AudioFile);
            await _context.songs.AddAsync(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<Song> DeleteSong(Guid id)
        {
            var song = _context.songs.Find(id);
            if (song == null)
            {
                throw new ArgumentException("Not found song");
            }
            _fileHelper.DeleteImageFile(song.SongImagePath);
            _fileHelper.DeleteAudioFile(song.SongPath);
            _context.songs.Remove(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public Task<List<Song>> GetAllSongs()
        {
            return _context.songs.ToListAsync();
        }

        public async Task<Song> GetSongById(Guid id)
        {
            var song = await _context.songs.FindAsync(id);
            if (song == null)
            {
                throw new ArgumentException("Not found song");
            }
            return song;
        }

        public async Task<Song> UpdateSong(Guid id, SongDTO songDTO)
        {
            Song? song = _context.songs.Find(id);
            if (song == null)
            {
                throw new ArgumentException("Not found song");
            }
            _mapper.Map(songDTO, song);
            string imagePath = song.SongImagePath;
            string audioPath = song.SongPath;
            song.SongImagePath = await _fileHelper.UploadFileImage(songDTO.ImageFile);
            song.SongPath = await _fileHelper.UploadFileAudio(songDTO.AudioFile);
            _fileHelper.DeleteImageFile(imagePath);
            _fileHelper.DeleteAudioFile(audioPath);
            await _context.SaveChangesAsync();
            return song;
        }
    }
}
