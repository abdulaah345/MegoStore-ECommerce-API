using MegoStore.Application.Dtos;
using MegoStore.Application.Interfaces;
using MegoStore.Domain.Entities.Identity;
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

        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(dto);
            if (!result.IsAuthentcated)
                return BadRequest(result.message);
            return Ok(result);
        }


            [HttpPost("Login")]

            public async Task<IActionResult>LoginAsync([FromBody] LoginDto loginDto)
            {
                if (!ModelState.IsValid)

                    return BadRequest(ModelState);

                var result = await _authService.LoginAsync(loginDto);
                if (!result.IsAuthentcated)
                    return BadRequest(result.message);
                return Ok(result);


            }


        [HttpPost("AddRole")]

        public async Task<IActionResult> AddRoleAsync([FromBody]AddRoleModel model)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);
            return Ok(model);


        }
    }
}
