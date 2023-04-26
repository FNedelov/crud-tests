using CRUD.API.Interfaces;
using CRUD.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
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

        [HttpPost]
        [AllowAnonymous]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequestDto authenticationRequest)
        {
            var authenticationResponse = await _authService.GenerateJwtToken(authenticationRequest);
            return authenticationResponse == default ? Unauthorized() : Ok(authenticationResponse);
        }
    }
}