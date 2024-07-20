using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Data.DTOs;
using MusicApi.Helper.Helpers;
using MusicApi.Infracstructure.Services.AlbumService;

namespace MusicApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly FileHelper _fileHelper;
        public AlbumController(IAlbumService albumService, FileHelper fileHelper)
        {
            this._albumService = albumService;
            _fileHelper = fileHelper;
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
        public async Task<IActionResult> CreatAlbum([FromForm] AlbumDTO albumDTO)
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
                var album=await _albumService.CreatAlbum(albumDTO);
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
        [HttpGet("songs/{id}")]
        public async Task<IActionResult> GetAllSong(Guid id)
        {
            try
            {
                var songs = await _albumService.GetAllSongOfAlbum(id);
                return Ok(new { status = true, message = "Get data successfully", data = songs });
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(Guid id)
        {
            try
            {
                await _albumService.DeleteAlbum(id);
                return Ok(new { status = true, message = "Delete data successfully" });
            }
            catch(Exception ex)
            {
                return Ok(new { status = false, message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum([FromRoute] Guid id, [FromBody] AlbumDTO albumDTO)
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
                var album = await _albumService.UpdateAlbum(id, albumDTO);
                return Ok(new
                {
                    status=true,
                    message="Update successfully",
                    data=album
                });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
        [HttpPut("{albumId}/{songId}")]
        public async Task<IActionResult> AddSongToAlbum([FromRoute] Guid albumId, [FromRoute] Guid songId)
        {
            try
            {
                await _albumService.AddSongToAlbum(albumId,songId);
                return Ok(new { status = true, message = "Add song to album successfully" });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }

        [HttpGet("image/{imageName}")]
        public async Task<IActionResult> GetAlbumImage(string imageName)
        {
            var resource = await _fileHelper.GetFileImage(imageName);
            if (resource == null)
            {
                return NotFound();
            }
            return File(resource, "image/jpeg");
        }
    }
}
