using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Helper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Service.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly JwtTokenHelper _jwtHelper;
        private readonly ApplicationDbContext _context;
        public AuthService(JwtTokenHelper jwt, ApplicationDbContext context) {
            _context = context;
            _jwtHelper = jwt;
        }
        public async Task<TokenDTO> Login(LoginDTO req)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.UserName == req.Email);
            if (user == null) {
                throw new Exception("Incorrect username or password");
            }
            if(!BCrypt.Net.BCrypt.Verify(req.Password, user.Password)){
                throw new Exception("Incorrect username or password");
            }
            Token refereshToken = new Token()
            {
                RefereshToken = _jwtHelper.GenerateRefereshToken(),
                CreatedAt=long.Parse(DateTime.UtcNow.ToString()),
                ExpirationTime=long.Parse(DateTime.UtcNow.AddDays(10).ToString()),
                isRevoked=false,
                user = user,
            };
            var accessToken = _jwtHelper.GenerateAccessToken(user);
            //add token to database
            await _context.SaveChangesAsync();
            return new TokenDTO
            {
                AccessToken= accessToken,
                RefereshToken=refereshToken.RefereshToken
            };
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Register()
        {
            throw new NotImplementedException();
        }
    }
}
