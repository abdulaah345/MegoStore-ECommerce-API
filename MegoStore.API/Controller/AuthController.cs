using MegoStore.Application.Dtos;
using MegoStore.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MegoStore.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]

        public async Task<IActionResult>RegisterAsync([FromBody]RegisterDto dto)
        {
            if(!ModelState.IsValid)
            
                return BadRequest(ModelState);

            var result=await _authService.RegisterAsync(dto);
            if(!result.IsAuthentcated)
                return BadRequest(result);
            return Ok(result);

            
        }
    }
}
