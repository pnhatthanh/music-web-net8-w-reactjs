using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using music_api.Attributes;
using MusicApi.Data.DTOs;
using MusicApi.Infracstructure.Services.PlayListService;
using System.Security.Claims;

namespace MusicApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
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
                    status=true, message="Create data successfully"
                });
            }catch (Exception ex)
            {
                return BadRequest(new
                {
                    status=false, message=ex.Message
                });
            }
        }

        [HttpPut("song/{idPlayList}/{idSong}")]
        public async Task<IActionResult> AddSongToPlayList( Guid idPlayList, Guid idSong)
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
        public async Task<IActionResult> GetAllPlayList() 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(new { status = false, message = "User is not authorized" });
            }
            try
            {
                var playLists = await _playListService.GetPlayListsOfUser(Guid.Parse(userId));
                return Ok(new
                {
                    status=true, message="Get data successfully", data=playLists
                });
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayListById(Guid id)
        {
            try
            {
                var playLists = await _playListService.GetPlayListById(id);
                return Ok(new
                {
                    status = true,
                    message = "Get data successfully",
                    data = playLists
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/songs")]
        public async Task<IActionResult> GetSongs(Guid id)
        {
            try
            {
                var songs = await _playListService.GetSongs(id);
                return Ok(new{ status = true, message = "Get data successfully", data = songs });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("remove/song/{idPlayList}/{idSong}")]
        public async Task<IActionResult> RemoveSongFromPlayList( Guid idPlayList, Guid idSong)
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
