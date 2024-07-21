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
        private readonly FileHelper _fileHelper;
        private readonly IMapper _mapper;
        public ArtistService(ApplicationDbContext context, FileHelper fileHelper, IMapper mapper)
        {
            _artistRepository=new ArtistRepository(context);
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
            await _artistRepository.Delete(artist);
            return artist;
        }

        public async Task<IEnumerable<ArtistResponse>> GetAllArtists()
        {
            return _mapper.Map<IEnumerable<ArtistResponse>>(await _artistRepository.GetAll());
        }

        public async Task<Artist> GetArtistById(Guid id)
        {
            Artist artist = await _artistRepository.FirstOrDefaultWithIncludes(a=>a.ArtistId==id,a=>a.Songs!)
               ?? throw new ArgumentException("Not found artist");
            return artist;
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
