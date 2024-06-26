using AutoMapper;
using Microsoft.EntityFrameworkCore;
using music_api.Data;
using music_api.DTOs;
using music_api.Helpers;
using music_api.Models;
using music_api.Services.IRepositories;

namespace music_api.Services
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly FileHelper _fileHelper;
        private readonly IMapper _mapper;
        public ArtistRepository(ApplicationDbContext context, FileHelper fileHelper, IMapper mapper)
        {
            _context = context;
            _fileHelper = fileHelper;
            _mapper = mapper;
        }

        public async Task<Artist> AddArtist(ArtistDTO artistDTO)
        {
           Artist artist=_mapper.Map<Artist>(artistDTO);
           _context.artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> DeleteArtist(Guid id)
        {
            Artist? artist = _context.artists.Find(id);
            if (artist==null)
            {
                throw new ArgumentException("Not found artist");   
            }
            _context.artists.Remove(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<List<Artist>> GetAllArtists()
        {
            return await _context.artists.ToListAsync();
        }

        public async Task<Artist> GetArtistById(Guid id)
        {
            Artist? artist =await _context.artists.FindAsync(id);
            if (artist == null)
            {
                throw new ArgumentException("Not found artist");
            }
            return artist;
        }

        public async Task<Artist> UpdateArtist(Guid id, ArtistDTO artistDTO)
        {
            Artist? artist = await _context.artists.FindAsync(id);
            if(artist == null)
            {
                throw new ArgumentException("Not found artist");
            }
            _mapper.Map(artistDTO, artist);
            await _context.SaveChangesAsync();
            return artist;
        }
    }
}
