using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using music_api.DTOs;
using music_api.Models;
using music_api.Services.IRepositories;

namespace music_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistController(IArtistRepository artistRepository) {
            _artistRepository = artistRepository;
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
                var artists = await _artistRepository.GetAllArtists();
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
                var artist =await _artistRepository.GetArtistById(id);
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
                var artist =await _artistRepository.AddArtist(request);
                return Ok(new { status = true, message = "Create successfully", data = artist });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { status = false, message = ex.Message});
            }
        }

    }
}
