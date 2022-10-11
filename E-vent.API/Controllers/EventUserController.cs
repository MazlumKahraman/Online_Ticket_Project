using E_vent.API.Helpers.Attributes;
using E_vent.Business.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class EventUserController : ControllerBase
    {
        private IEventUserService _eventUserService;

        public EventUserController(IEventUserService eventUserService)
        {
            _eventUserService = eventUserService;
        }

        [HttpGet("GetAll")]
        public List<EventUser> GetAll()
        {
            return _eventUserService.GetAll(e => e.IsActive);
        }

        [HttpGet("Get/{id}")]
        public EventUser Get(int id)
        {
            return _eventUserService.Get(e => e.Id == id && e.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] EventUser eventUser)
        {
            _eventUserService.Add(eventUser);
            return Ok(eventUser);
        }

        [HttpPut("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var eventUser = _eventUserService.Get(e => e.Id == id && e.IsActive);
            if (eventUser is not null)
            {
                eventUser.IsActive = false;
                _eventUserService.Update(eventUser);
                return NoContent();
            }
            return BadRequest("EventUser not found");
        }

        [HttpPut("Update")]
        public ActionResult Update(EventUser eventUser)
        {
            var updateEventUser = _eventUserService.Get(e => e.Id == eventUser.Id && e.IsActive);
            if (updateEventUser is not null)
            {
                _eventUserService.Update(eventUser);
                return Ok(eventUser);
            }
            return BadRequest("EventUser not found");
        }
    }
}
