using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Data.DTOs;
using MusicApi.Service.Services.ArtistService;

namespace MusicApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        public ArtistController(IArtistService artistService) {
            _artistService = artistService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        /// Sample request: Get api/v1/artist
        [HttpGet]

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Sample request: Get api/v1/artist/string

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistById(Guid id)
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

        [HttpPost]
        
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
                return Ok(new { status = true, message = "Create successfully", data = artist });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { status = false, message = ex.Message});
            }
        }

    }
}
