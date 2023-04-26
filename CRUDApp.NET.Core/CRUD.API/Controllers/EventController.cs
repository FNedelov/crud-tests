using CRUD.API.Interfaces;
using CRUD.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        //public async Task CreateEvent(RequestDataDto eventData)

        [HttpPost]
        [AllowAnonymous]
        [Route("CreateEvent")]
#warning decide who can access endpoint
        //[Authorize(Roles = $"{Constants.ROLE_ADMIN}, {Constants.ROLE_USER}")]
        public async Task CreateEvent([FromBody] RequestDataDto eventData)
        {
            await _eventService.CreateEvent(eventData);
        }
    }
}