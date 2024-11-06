using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using music_api.Caches;
using music_api.Caches.RedisCaching;
using MusicApi.Data.DTOs;
using MusicApi.Helper.Helpers;
using MusicApi.Infracstructure.Services.ArtistService;
using System;

namespace MusicApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IRedisService _redisService;
        //private readonly FileHelper _fileHelper;
        public ArtistController(IArtistService artistService/*, FileHelper fileHelper*/, IRedisService redisService) {
            _artistService = artistService;
            _redisService = redisService;
            //_fileHelper = fileHelper;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        /// Sample request: Get api/v1/artist
        [HttpGet]
        [Cache(100)]
        public async Task<IActionResult> GetArtists()
        {
            try
            {
                var artists = await _artistService.GetAllArtists();
                return artists.Any() ?
                        Ok(new { status = true, message = "Get data succesfully", data = artists })
                        : NoContent();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { status = false, message = ex.Message });
            }
        }

        [HttpGet("paged")]
        [Cache(100)]
        public async Task<IActionResult> GetArtistsWithPaged([FromQuery]int? page,[FromQuery]int? pageSize)
        {
            try
            {
                var artists = await _artistService.GetAllArtistsWithPaged(page,pageSize);
                return artists.Any() ?
                        Ok(new { status = true, message = "Get data succesfully", data = artists })
                        : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { status = false, message = ex.Message });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Sample request: Get api/v1/artist/string

        [HttpGet("{id}")]
        [Cache(100)]
        public async Task<IActionResult> GetArtistById([FromRoute] Guid id)
        {
            try
            {
                var artist =await _artistService.GetArtistById(id);
                return Ok(new { status = true, message = "Get data succesfully", data = artist });
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, 
                    new { status = false,message = ex.Message});
            }
        }

        [HttpGet("{id}/songs/paged")]
        [Cache(100)]
        public async Task<IActionResult> GetAllSong(int page, int pageSize, Guid id)
        {
            try
            {
                var songs = await _artistService.GetAllSongs(page, pageSize, id);
                return songs.Any() ?
                        Ok(new { status = true, message = "Get data succesfully", data = songs })
                        : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { status = false, message = ex.Message });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ///     POST /api/v1/Artist
        ///     {
        ///         "ArtistName": "string",
        ///         "Country": "string",
        ///         "YearOfBirth": int,
        ///         ...
        ///     }

        [HttpPost("add")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddArtist([FromForm] ArtistDTO request) {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { status = false,
                    message = "Invalid data",
                    errors = ModelState.Values.SelectMany(v=>v.Errors).Select(e=>e.ErrorMessage)});
            }
            try
            {
                var artist =await _artistService.AddArtist(request);
                await _redisService.RemoveCacheAsync("/artist/*");
                return Ok(new { status = true, message = "Create successfully", data = artist });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { status = false, message = ex.Message});
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Sample request: Delete api/v1/artist/string

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteArtist([FromRoute] Guid id)
        {
            try
            {
                await _artistService.DeleteArtist(id);
                await _redisService.RemoveCacheAsync("/artist/*");
                return Ok(new { status = true, message = "Delete data successfully" });
            }
            catch(Exception ex)
            {
                return Ok(new {status=true, message=ex.Message});
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateArtist([FromRoute] Guid id, [FromBody] ArtistDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Invalid data",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            try
            {
                var artist = await _artistService.UpdateArtist(id, request);
                await _redisService.RemoveCacheAsync("/artist/*");
                return Ok(new { status = true, message = "Update data sucsessfully", data = artist });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new{
                        status=false,
                        message=ex.Message
                    });
            }
        }
        //[HttpGet("image/{imageName}")]
        //public async Task<IActionResult> GetArtistImage(string imageName)
        //{
        //    var resource = await _fileHelper.GetFileImage(imageName);
        //    if (resource == null)
        //    {
        //        return NotFound();
        //    }
        //    return File(resource, "image/jpeg");
        //}

    }
}
