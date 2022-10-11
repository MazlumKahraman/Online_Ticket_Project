using E_vent.API.Helpers.Attributes;
using E_vent.Business.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class EventController : ControllerBase
    {
        private IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("GetAll")]
        public List<Event> GetAll()
        {
            return _eventService.GetAll(e => e.IsActive);
        }

        [HttpGet("Get/{id}")]
        public Event Get(int id)
        {
            return _eventService.Get(e => e.Id == id && e.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Event @event)
        {
            _eventService.Add(@event);
            return Ok(@event);
        }

        [HttpPut("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var currentEvent = _eventService.Get(e => e.Id == id && e.IsActive);
            if (currentEvent is not null)
            {
                currentEvent.IsActive = false;
                _eventService.Update(currentEvent);
                return NoContent(); 
            }
            return BadRequest("Event not found");
        }

        [HttpPut("Update")]
        public ActionResult Update(Event @event)
        {
            var updateEvent = _eventService.Get(e => e.Id == @event.Id && e.IsActive);
            if (updateEvent is not null)
            {
                _eventService.Update(@event);
                return Ok(@event);
            }
            return BadRequest("City not found");
        }
    }
}
