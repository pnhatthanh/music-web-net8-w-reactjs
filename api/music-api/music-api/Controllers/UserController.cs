using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Data.DTOs;
using MusicApi.Infracstructure.Services.UserService;
using System.Security.Claims;

namespace MusicApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    status = false,
                    message = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            try
            {
                 await _userService.CreateAccount(registerDTO);
                return Ok(new
                {
                    status = true, message = "Register successfully"
                });
            }catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status=false, message=ex.Message    
                });
            }
        }

        [HttpGet("favourite/songs")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetFavourites()
        {
            var userId=User.Claims.First(c=>c.Type==ClaimTypes.NameIdentifier).Value;
            if (userId == null)
            {
                return Unauthorized(new { status = false, message = "User is not authorized" });
            }
            try
            {
                var favourites =await _userService.GetFavouriteSongs(Guid.Parse(userId));
                return Ok(new
                {
                    status=true, message="Get data successfully", data=favourites
                });
            }catch(Exception ex)
            {
                return StatusCode(500, new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
        [HttpPut("favourite/add/song/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddSongToFavourite([FromRoute] Guid id)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (userId == null)
            {
                return Unauthorized(new { status = false, message = "User is not authorized" });
            }
            try
            {
                var song =await _userService.AddSongToFavourites(id, Guid.Parse(userId));
                return Ok(new
                {
                    status=true, message="Add song to favourite successfully", data=song
                });
            }catch(Exception ex)
            {
                return StatusCode(500, new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
        [HttpPut("favourite/remove/song/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RemoveSongFromFavourite([FromRoute] Guid id)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (userId == null)
            {
                return Unauthorized(new { status = false, message = "User is not authorized" });
            }
            try
            {
                await _userService.RemoveSongFromFavourite(id, Guid.Parse(userId));
                return Ok(new
                {
                    status = true,
                    message = "Remove song from favourite successfully",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
    }
}
 