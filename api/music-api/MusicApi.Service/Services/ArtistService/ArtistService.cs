using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;
using MusicApi.Helper.Helpers;
using MusicApi.Infracstructure.Repositories;
using MusicApi.Infracstructure.Repositories.IRepository;

namespace MusicApi.Infracstructure.Services.ArtistService
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ISongRepository _songRepository;
        private readonly FileHelper _fileHelper;
        private readonly IMapper _mapper;
        public ArtistService(ApplicationDbContext context, FileHelper fileHelper, IMapper mapper)
        {
            _artistRepository=new ArtistRepository(context);
            _songRepository=new SongRepository(context);
            _fileHelper = fileHelper;
            _mapper = mapper;
        }

        public async Task<Artist> AddArtist(ArtistDTO artistDTO)
        {
            Artist artist = _mapper.Map<Artist>(artistDTO);
            artist.ImagePath = await _fileHelper.UploadFileImage(artistDTO.Image!);
            await _artistRepository.AddAsynch(artist);
            return artist;
        }

        public async Task<Artist> DeleteArtist(Guid id)
        {
            Artist? artist =await _artistRepository.GetByIdAsynch(id)
                ?? throw new ArgumentException("Not found artist");
            await _fileHelper.DeleteImageFile(artist.ImagePath);
            await _artistRepository.Delete(artist);
            return artist;
        }
        public async Task<IEnumerable<ArtistResponse>> GetAllArtists()
        {
            return _mapper.Map<IEnumerable<ArtistResponse>>(await _artistRepository.GetAll());
        }
        public async Task<IEnumerable<ArtistResponse>> GetAllArtistsWithPaged(int? page, int? pageSize)
        {
            if(page <1) page = 1;
            return _mapper.Map<IEnumerable<ArtistResponse>>
                (await _artistRepository.GetAllPaged(page,pageSize));
        }

        public async Task<IEnumerable<SongResponse>> GetAllSongs(int page, int pageSize ,Guid id)
        {
            if(page <1) page = 1;
            return _mapper.Map<IEnumerable<SongResponse>>
                (await _songRepository.GetManyWithIncludes(s=>s.ArtistId==id,s=>s.artist!))
                .OrderBy(s=>s.ListenCount)
                .Skip((page-1)*pageSize)
                .Take(pageSize);
        }

        public async Task<Artist> GetArtistById(Guid id)
        {
            Artist artist = await _artistRepository.FirstOrDefaultWithIncludes(a=>a.ArtistId==id,a=>a.Songs!)
               ?? throw new ArgumentException("Not found artist");
            return artist;
        }

        public async Task<IEnumerable<ArtistResponse>> GetArtistByName(string name)
        {
            return _mapper.Map<IEnumerable<ArtistResponse>>
                (await _artistRepository.GetMany(a => EF.Functions.Like(a.ArtistName,$"{name}%")));
        }

        public async Task<Artist> UpdateArtist(Guid id, ArtistDTO artistDTO)
        {
            Artist? artist = await _artistRepository.GetByIdAsynch(id)
                    ?? throw new ArgumentException("Not found artist");
            _mapper.Map(artistDTO, artist);
            await _artistRepository.UpdateAsynch(artist);
            return artist;
        }
    }
}
