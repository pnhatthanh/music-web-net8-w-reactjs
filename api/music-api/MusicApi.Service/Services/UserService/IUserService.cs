using MusicApi.Data.DTOs;

namespace MusicApi.Service.Services.UserService
{
    public interface IUserService
    {
        Task<UserDTO> CreateAccount(UserDTO userDTO);
    }
}
