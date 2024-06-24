using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using music_api.Data;
using music_api.DTOs;
using music_api.Helpers;
using music_api.Models;
using music_api.Services.IRepositories;

namespace music_api.Services
{
    public class AlbumRepository : IAlbumRepository
    {
        public readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;
        private readonly FileHelper _fileHelper;
        public AlbumRepository(ApplicationDbContext context,IMapper mapper,FileHelper fileHelper)
        {
            _context = context;
            _mapper = mapper;
            _fileHelper = fileHelper;
        }

        public async Task<Album> CreatAlbum(AlbumDTO albumDTO)
        {
            Album album = _mapper.Map<Album>(albumDTO);
            album.ImagePath =await _fileHelper.UploadFileImage(albumDTO.ImageFile);
            _context.albums.Add(album);
            albumDTO.SongIDs.ForEach(async songID =>
            {
                 await AddSongToAlbum(songID, album);
            });
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> DeleteAlbum(long id)
        {
            var album=await _context.albums.FindAsync(id);
            if (album == null)
            {
                throw new Exception("Not found");
            }
            _context.albums.Remove(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> GetAlbumById(long id)
        {
            var album = await _context.albums.FindAsync(id);
            if (album == null)
            {
                throw new Exception("Not found");
            }
            return album;
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            return await _context.albums.ToListAsync();
        }

        public async Task<Album> UpdateAlbum(Guid id,AlbumDTO albumDTO)
        {
            var album=_context.albums.Find(id);
            if(album == null)
            {
                throw new ArgumentException("Not found album");
            }
            _mapper.Map(albumDTO, album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task AddSongToAlbum(Guid songId, Album album)
        {
            Song? song=await _context.songs.FindAsync(songId);
            if (song == null)
            {
                throw new Exception("Not found song");
            }
            song.AlbumId = album.AlbumId;
            await _context.SaveChangesAsync();
        }
    }
}
