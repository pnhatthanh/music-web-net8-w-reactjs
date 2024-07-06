using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Data.DTOs;
using MusicApi.Data.Models;
using MusicApi.Helper.Helpers;
using MusicApi.Service.Services.SongService;

namespace MusicApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly FileHelper _fileHelper;
        public SongController(ISongService songService, FileHelper fileHelper)
        {
            _songService = songService;
            _fileHelper = fileHelper;  
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            try
            {
                var songs = await _songService.GetAllSongs();
                return songs.Any() ? Ok(new { status = true, message = "Get data successfully", data = songs })
                    : NoContent();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    status = false,
                    message = ex.Message,
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong(Guid id)
        {
            try
            {
                var song = await _songService.GetSongById(id);
                return Ok(new { staus = true, message = "Get data successfully", data = song });
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    status = false,
                    message = ex.Message,
                });
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> CreateSong([FromForm] SongDTO songDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    status = false,
                    error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            try
            {
                var song = await _songService.CreatSong(songDTO);
                return Ok(new { status = true, message = "Creat data successfully", data = song });
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { status = false, message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong([FromRoute] Guid id)
        {
            try
            {
                await _songService.DeleteSong(id);
                return Ok(new { status = true, message = "Delete data successfully" });
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong([FromRoute] Guid id, [FromForm] SongDTO songDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    status = false,
                    error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            try
            {
                var song = await _songService.UpdateSong(id, songDTO);
                return Ok(new {status=true, message="Update data successfully",data=song});
            }catch (Exception ex) {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    status=false,
                    message=ex.Message
                });
            }
        }

        [HttpGet("image/{url}")]
        public async Task<IActionResult> GetSongImage([FromRoute]  string url)
        {
            var resource =await _fileHelper.GetFileImage(url);
            if(resource == null)
            {
                return NotFound();
            }
            return File(resource, "image/jpeg");
        }

        [HttpGet("audio/{url}")]
        public async Task<IActionResult> GetSongAudio([FromRoute] string url)
        {
            var resource = await _fileHelper.GetFileAudio(url);
            if (resource == null)
            {
                return NotFound();
            }
            return File(resource, "audio/mpeg");
        }
    }
}
