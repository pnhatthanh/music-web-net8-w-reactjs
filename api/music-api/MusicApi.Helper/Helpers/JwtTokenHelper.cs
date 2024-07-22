using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicApi.Data.Migrations;
using MusicApi.Data.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Helper.Helpers
{
    public class JwtTokenHelper
    {
        private readonly IConfiguration _config;
        public JwtTokenHelper(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role!.RoleName),
                new Claim(JwtRegisteredClaimNames.Sub,_config.GetSection("Jwt:Subject").Value ?? 
                    throw new InvalidOperationException("Occur error internal")),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value 
                      ?? throw new InvalidOperationException("Occur error internal")));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    issuer: _config.GetSection("Jwt:Issuer").Value,
                    audience: _config.GetSection("Jwt:Audience").Value,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(Double.Parse(_config.GetSection("Jwt:ExpiredDayTime").Value 
                            ?? throw new InvalidOperationException("Occur error internal"))),
                    signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Token GenerateRefereshToken(Guid userId)
        { 
            return new Token()
            {
                RefereshToken = Guid.NewGuid().ToString(),
                CreatedAt = DateTimeOffset.Now.ToUnixTimeSeconds(),
                ExpirationTime = DateTimeOffset.Now.AddDays(30).ToUnixTimeSeconds(),
                IsRevoked = false,
                userId = userId,
            };
        }
    }
}
