using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;
using MusicApi.Helper.Helpers;
using MusicApi.Infracstructure.Repositories;
using MusicApi.Infracstructure.Repositories.IRepository;

namespace MusicApi.Infracstructure.Services.SongService
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;
        private readonly FileHelper _fileHelper;
        public SongService(ApplicationDbContext context, FileHelper fileHelper, IMapper mapper)
        {
            _songRepository=new SongRepository(context);
            _mapper = mapper;
            _fileHelper = fileHelper;
        }
        public async Task<Song> CreatSong(SongDTO songDTO)
        {
            Song song = _mapper.Map<Song>(songDTO);
            song.SongImagePath = await _fileHelper.UploadFileImage(songDTO.ImageFile!);
            song.SongPath = await _fileHelper.UploadFileAudio(songDTO.AudioFile!);
            await _songRepository.AddAsynch(song);
            return song;
        }
        public async Task<Song> DeleteSong(Guid id)
        {
            var song = await _songRepository.GetByIdAsynch(id) 
                ?? throw new ArgumentException("Not found song");
            await _fileHelper.DeleteImageFile(song.SongImagePath);
            await _fileHelper.DeleteAudioFile(song.SongPath);
            await _songRepository.Delete(song);
            return song;
        }

        public async Task<IEnumerable<SongResponse>> GetAllSongs(int page, int pageSize)
        {
            if (page < 1) page = 1;
            return _mapper.Map<IEnumerable<SongResponse>>
                    (await _songRepository.GetAllPaged(page,pageSize,s => s.artist!));
        }

        public async Task<IEnumerable<SongResponse>> GetQueue(Guid[] idSongs)
        {
            var songs = await _songRepository.GetManyWithIncludes(s => idSongs.Contains(s.SongId), s => s.artist!);
            return _mapper.Map<IEnumerable<SongResponse>>(songs);
        }

        public async Task<SongResponse> GetSongById(Guid id)
        {
            return _mapper.Map<SongResponse>(await _songRepository.FirstOrDefaultWithIncludes(s => s.SongId == id, s => s.artist!))
                ?? throw new ArgumentException("Not found song");
        }
        public async Task<Song> UpdateSong(Guid id, SongDTO songDTO)
        {
            Song song = await _songRepository.GetByIdAsynch(id) 
                ?? throw new ArgumentException("Not found song");

            _mapper.Map(songDTO, song);
            string imagePath = song.SongImagePath;
            string audioPath = song.SongPath;
            song.SongImagePath = await _fileHelper.UploadFileImage(songDTO.ImageFile!);
            song.SongPath = await _fileHelper.UploadFileAudio(songDTO.AudioFile!);
            await _fileHelper.DeleteImageFile(imagePath);
            await _fileHelper.DeleteAudioFile(audioPath);

            await _songRepository.UpdateAsynch(song);
            return song;
        }
    }
}
