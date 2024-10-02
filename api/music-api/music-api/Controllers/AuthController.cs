using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Data.DTOs;
using MusicApi.Infracstructure.Services.AuthService;

namespace music_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO req)
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
                var token = await _authService.Login(req);
                return Ok(new
                {
                    status = true,
                    message = "Login successfully",
                    data = token
                });
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,ex.Message);
            } 
        }
        //[HttpPost("login/via-google")]
        //public async Task<IActionResult> LoginViaGoogle([FromBody] string idToken)
        //{
        //    try
        //    {

        //    }catch(Exception ex) {
        //        return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        //    }
        //}

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(TokenDTO tokenDTO)
        {
            try
            {
                await _authService.Logout(tokenDTO);
                return Ok( new
                {
                    status = true, message = "Logout successfully"
                });
            }catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = false, message = ex.Message
                });
            }
        }
        [HttpPost("referesh")]
        public async Task<IActionResult> RefereshAccout([FromBody] TokenDTO _token)
        {
            try
            {
                var token = await _authService.VerifyAndGenerateToken(_token.RefereshToken!);
                return Ok(new
                {
                    status = true, message = "Referesh successfully", data = token
                });
            }catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = false, message = ex.Message
                });
            }
        }
    }
}
