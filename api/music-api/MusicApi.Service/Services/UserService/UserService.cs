using MusicApi.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Service.Services.UserService
{
    public class UserService : IUserService
    {
        public Task<UserDTO> CreateAccount(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
