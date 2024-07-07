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

namespace MusicApi.Service.Services.UserService
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
    }
}
