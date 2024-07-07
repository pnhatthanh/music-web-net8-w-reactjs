using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Data.DTOs;
using MusicApi.Service.Services.PlayListService;
using System.Security.Claims;

namespace MusicApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlayListController : ControllerBase
    {
        private readonly IPlayListService _playListService;
        public PlayListController(IPlayListService playListService)
        {
            _playListService = playListService;
        }

        [HttpPost("creat")]
        public  async Task<IActionResult> CreatePlayList([FromBody] PlayListDTO playListDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    status = false,
                    message = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(username == null)
            {
                return Unauthorized(new { status = false, message = "User is not authorized" });
            }
            try
            {
                var playList = await _playListService.AddPlayList(playListDTO, Guid.Parse(username));
                return Ok(new
                {
                    status=true, message="Create data successfully", data = playList
                });
            }catch (Exception ex)
            {
                return BadRequest(new
                {
                    status=false, message=ex.Message
                });
            }
        }

        [HttpPut("add/song")]
        public async Task<IActionResult> AddSongToPlayList([FromBody] Guid idPlayList, [FromBody] Guid idSong)
        {
            try
            {
                await _playListService.AddSongToPlayList(idPlayList, idSong);
                return Ok(new
                {
                    stauts = true, message = "Add song to playlist successfully"
                });
            }catch(Exception ex)
            {
                return BadRequest(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetPlayList() 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(new { status = false, message = "User is not authorized" });
            }
            try
            {
                var playLists = await _playListService.GetPlayListById(Guid.Parse(userId));
                return Ok(new
                {
                    status=true, message="Get data successfully", data=playLists
                });
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("remove/song")]
        public async Task<IActionResult> RemoveSongFromPlayList([FromBody] Guid idPlayList, [FromBody] Guid idSong)
        {
            try
            {
                await _playListService.RemoveSongFromPlayList(idPlayList, idSong);
                return Ok(new
                {
                    stauts = true,
                    message = "Remove song from playlist successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePlayList([FromRoute] Guid id)
        {
            try
            {
                await _playListService.DeletePlayList(id);
                return Ok(new
                {
                    status = true, message="Delete data successfully"
                });
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
