using CRUD.API.Interfaces;
using CRUD.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public ForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        [Authorize(Roles = $"{Constants.ROLE_ADMIN}, {Constants.ROLE_USER}")]
        [Route("GetForecast")]
        public async Task<IActionResult> GetForecast()
        {
            return Ok(await _forecastService.GetForecast());
        }
    }
}