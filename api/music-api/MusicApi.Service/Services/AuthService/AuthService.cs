using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.Configuration;
using MusicApi.Data.Data;
using MusicApi.Data.DTOs;
using MusicApi.Data.Migrations;
using MusicApi.Data.Models;
using MusicApi.Helper.Helpers;
using MusicApi.Infracstructure.Repositories;
using MusicApi.Infracstructure.Repositories.IRepository;
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
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        public AuthService(JwtTokenHelper jwt, ApplicationDbContext context) {
            _tokenRepository = new TokenRepository(context);
            _userRepository = new UserRepository(context);
            _jwtHelper = jwt;
        }
        public async Task<TokenDTO> Login(LoginDTO req)
        {
            var user = await _userRepository.FirstOrDefaultWithIncludes(u=>u.UserName==req.Email,u=>u.Role!);
            if(user==null)
            {
                throw new Exception("Incorrect username or password");
            }
            if (!BCrypt.Net.BCrypt.Verify(req.Password,user.Password)){
                throw new Exception("Incorrect username or password");
            }
            var accessToken = _jwtHelper.GenerateAccessToken(user);
            Token refereshToken = _jwtHelper.GenerateRefereshToken(user.UserId);
            await _tokenRepository.AddAsynch(refereshToken);
            return new TokenDTO
            {
                AccessToken= accessToken,
                RefereshToken=refereshToken.RefereshToken
            };
        }

        //public Task<TokenDTO> LoginViaGoogle(string idToken)
        //{
        //    //var setting =new GoogleJ
        //}

        public async Task Logout(TokenDTO token)
        {
            var refereshToken =await _tokenRepository.FirstOrDefaultAsynch(t => t.RefereshToken == token.RefereshToken);
            if (refereshToken == null)
            {
                throw new Exception("Invalid token");
            }
            await _tokenRepository.Delete(refereshToken);
        }
        public async Task<TokenDTO> VerifyAndGenerateToken(string refereshToken)
        {
            var token = await _tokenRepository.FirstOrDefaultAsynch(t => t.RefereshToken == refereshToken) 
                        ?? throw new Exception("Token invalid");
            if (token.IsRevoked == true || token.ExpirationTime < DateTimeOffset.Now.ToUnixTimeSeconds())
            {
                throw new Exception("Token is expired");
            }
            await _tokenRepository.Delete(token);
            var user =await _userRepository.FirstOrDefaultWithIncludes(u => u.UserId == token.userId, u => u.Role!)
                       ?? throw new Exception("User not found");
            Token newRefereshToken = _jwtHelper.GenerateRefereshToken(user!.UserId);
            var accessToken = _jwtHelper.GenerateAccessToken(user);
            await _tokenRepository.AddAsynch(newRefereshToken);
            return new TokenDTO
            {
                AccessToken = accessToken,
                RefereshToken = newRefereshToken.RefereshToken
            };
        }
    }
}
