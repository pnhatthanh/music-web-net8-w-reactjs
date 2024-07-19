using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Migrations;
using MusicApi.Data.Models;
using MusicApi.Helper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Services.AuthService
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
            Token refereshToken = _jwtHelper.GenerateRefereshToken(user.UserId);
            var accessToken = _jwtHelper.GenerateAccessToken(user);
            _context.tokens.Add(refereshToken);
            await _context.SaveChangesAsync();
            return new TokenDTO
            {
                AccessToken= accessToken,
                RefereshToken=refereshToken.RefereshToken
            };
        }
        public async Task Logout(TokenDTO token)
        {
            var refereshToken =await _context.tokens.FirstOrDefaultAsync(t => t.RefereshToken == token.RefereshToken);
            if (refereshToken == null)
            {
                throw new Exception("Invalid token");
            }
            _context.tokens.Remove(refereshToken);
            await _context.SaveChangesAsync();
        }
        public async Task<TokenDTO> VerifyAndGenerateToken(string refereshToken)
        {
            var token = await _context.tokens
                .Include(u=>u.User)
                .FirstOrDefaultAsync(t => t.RefereshToken == refereshToken);
            if(token == null)
            {
                throw new Exception("Token invalid");
            }
            if (token.IsRevoked == true || token.ExpirationTime < long.Parse(DateTime.UtcNow.ToString()))
            {
                throw new Exception("Token is expired");
            }
            _context.tokens.Remove(token);
            Token newRefereshToken = _jwtHelper.GenerateRefereshToken(token.userId);
            var accessToken = _jwtHelper.GenerateAccessToken(token.User!);
            _context.tokens.Add(newRefereshToken);
            await _context.SaveChangesAsync();
            return new TokenDTO
            {
                AccessToken = accessToken,
                RefereshToken = newRefereshToken.RefereshToken
            };
        }
    }
}
