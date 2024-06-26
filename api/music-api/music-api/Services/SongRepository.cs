using AutoMapper;
using Microsoft.EntityFrameworkCore;
using music_api.Data;
using music_api.DTOs;
using music_api.Helpers;
using music_api.Models;
using music_api.Services.IRepositories;

namespace music_api.Services
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly FileHelper _fileHelper;
        public SongRepository(ApplicationDbContext context,
            FileHelper fileHelper,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _fileHelper = fileHelper; 
        }
        public async Task<Song> CreatSong(SongDTO songDTO)
        {
            Song song=_mapper.Map<Song>(songDTO);
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
            string imagePath=song.SongImagePath;
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
