using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Data.Response;
using MusicApi.Infracstructure.Repositories;
using MusicApi.Infracstructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFavouriteRepository _userFavouriteRepository;
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _userRepository = new UserRepository(context);
            _userFavouriteRepository=new UserFavouriteRepository(context);
            _songRepository=new SongRepository(context);
            _mapper = mapper;
        }

        public async Task CreateAccount(RegisterDTO registerDTO)
        {
            if(registerDTO.Password != registerDTO.ConfirmPassword)
            {
                throw new Exception("Re-entered password does not match");
            }
            var exist=await _userRepository.Any(u=>u.UserName== registerDTO.UserName);
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
            await _userRepository.AddAsynch(user);
        }
        public async Task<Song> AddSongToFavourites(Guid idSong, Guid userId)
        {
            var song =await _songRepository.GetByIdAsynch(idSong)
                ?? throw new Exception("Song not found");
            var user = await _userRepository.GetByIdAsynch(userId)
                ?? throw new Exception("User not found");
            await _userFavouriteRepository.AddAsynch(new UserFavourite
            {
                SongId = song.SongId,
                UserId = userId
            });
            return song;
        }

        public async Task<PaginatedData> GetFavouriteSongs(Guid userId, int page, int pageSize)
        {
            if (page < 1) page = 1;
            return new PaginatedData
            {
                Data = _mapper.Map<IEnumerable<SongResponse>>(await _userFavouriteRepository.GetSongs(userId, page, pageSize)),
                PageIndex = page,
                ToltalItem= await _userFavouriteRepository.QuantityFavouriteSong(userId),
            };
        }

        public async Task RemoveSongFromFavourite(Guid idSong, Guid userId)
        {
            var userFavourite = await _userFavouriteRepository
                .FirstOrDefaultAsynch(u => u.UserId == userId && u.SongId == idSong)
                ?? throw new Exception("Song or user not found");
            await _userFavouriteRepository.Delete(userFavourite);
        }

    }
}
