using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateAccount(RegisterDTO registerDTO)
        {
            if(registerDTO.Password != registerDTO.Password)
            {
                throw new Exception("Re-entered password does not match");
            }
            var exist=await _context.users.AnyAsync(u=>u.UserName== registerDTO.UserName);
            if (exist == true)
            {
                throw new Exception("Account already exists");
            }
            User user=new User()
            {
                UserName=registerDTO.UserName!,
                Password=BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                RoleId=1
            };
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<Song> AddSongToFavourites(Guid idSong, Guid userId)
        {
            var song =await _context.songs.FindAsync(idSong);
            if (song == null)
            {
                throw new Exception("Song not found");
            }
            var user=await _context.users/*.Include(u=>u.Songs)*/
                .FirstOrDefaultAsync(u=>u.UserId == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            //user.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<List<Song>> GetFavouriteSongs(Guid userId)
        {
            return await _context.songs
                /*Where(s=>s.Users.Any(u=>u.UserId==userId))*/.ToListAsync();
        }

        public async Task RemoveSongFromFavourite(Guid idSong, Guid userId)
        {
            var song = await _context.songs.FindAsync(idSong);
            if (song == null)
            {
                throw new Exception("Song not found");
            }
            var user = await _context.users/*.Include(u => u.Songs)*/
                .FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            //user.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }

    }
}
