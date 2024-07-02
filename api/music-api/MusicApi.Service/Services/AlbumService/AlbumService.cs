using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Helper.Helpers;

namespace MusicApi.Service.Services.AlbumService
{
    public class AlbumService : IAlbumService
    {
        public readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;
        private readonly FileHelper _fileHelper;
        public AlbumService(ApplicationDbContext context, IMapper mapper, FileHelper fileHelper)
        {
            _context = context;
            _mapper = mapper;
            _fileHelper = fileHelper;
        }

        public async Task<Album> CreatAlbum(AlbumDTO albumDTO)
        {
            Album album = _mapper.Map<Album>(albumDTO);
            album.ImagePath = await _fileHelper.UploadFileImage(albumDTO.ImageFile);
            _context.albums.Add(album);
            albumDTO.SongIDs.ForEach(async songID =>
            {
                await AddSongToAlbum(album.AlbumId,songID);
            });
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> DeleteAlbum(Guid id)
        {
            var album = await _context.albums.FindAsync(id);
            if (album == null)
            {
                throw new Exception("Not found");
            }
            _context.albums.Remove(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> GetAlbumById(Guid id)
        {
            var album = await _context.albums
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(a=>a.AlbumId==id);
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

        public async Task<Album> UpdateAlbum(Guid id, AlbumDTO albumDTO)
        {
            var album = _context.albums.Find(id);
            if (album == null)
            {
                throw new ArgumentException("Not found album");
            }
            _mapper.Map(albumDTO, album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task AddSongToAlbum(Guid idAlbum, Guid idSong)
        {
            Album album = await GetAlbumById(idAlbum);
            Song? song = await _context.songs.FindAsync();
            if (song == null)
            {
                throw new Exception("Not found song");
            }
            album.Songs.Add(song);
            await _context.SaveChangesAsync();
        }
    }
}
