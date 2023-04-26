using CRUD.API.Interfaces;
using CRUD.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = $"{Constants.ROLE_ADMIN}, {Constants.ROLE_USER}")]
        [Route("GetUsersList")]
        public async Task<IActionResult> GetUsersList()
        {
            // Show active inactive decision client side - use checkbox
            return Ok(await _userService.GetUsersList());
        }
    }
}