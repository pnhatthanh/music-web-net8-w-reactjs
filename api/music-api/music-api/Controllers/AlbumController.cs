using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Data.DTOs;
using MusicApi.Service.Services.AlbumService;

namespace MusicApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            this._albumService = albumService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// Get api/v1/album
        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            try
            {
                var alnums = await _albumService.GetAllAlbums();
                return alnums.Any() ?
                    Ok(new { status = true, message = "Get Data successfully", data = alnums })
                    : NoContent();
            }catch (Exception ex) { 
                return StatusCode(500, new
                {
                    status=false,
                    message=ex.Message,
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumDTO"></param>
        /// <returns></returns>
        /// POST api/v1/album/add
        /// {
        ///     
        /// }
        [HttpPost("add")]
        public async Task<IActionResult> AddAlbum([FromForm] AlbumDTO albumDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    status = false,
                    error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            try
            {
                var album=_albumService.CreatAlbum(albumDTO);
                return Ok(new { status = true, message = "Create data successfully", data = album });
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    status = false,
                    message = ex.Message,
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumById(Guid id)
        {
            try
            {
                var album =await _albumService.GetAlbumById(id);
                return Ok(new {status=true, message="Get data successfully", data=album});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    status = false,
                    message = ex.Message,
                });
            }
        }
    }
}
