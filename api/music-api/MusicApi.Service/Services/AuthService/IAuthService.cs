using MusicApi.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Service.Services.AuthService
{
    public interface IAuthService
    {
        Task<TokenDTO> Login(LoginDTO req);
        Task<UserDTO> Register();
        Task Logout();
    }
}
