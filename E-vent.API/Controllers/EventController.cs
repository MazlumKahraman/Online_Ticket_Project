using E_vent.Business.Abstract;
using E_vent.Business.Concrete;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventService _eventService;

        public EventController()
        {
            _eventService = new EventManager(new EventDal());
        }

        [HttpGet("GetAllEvents")]
        public List<Event> GetAll()
        {
            return _eventService.GetAll(e => e.IsActive);
        }

        [HttpGet("Get")]
        public Event Get(int eventId)
        {
            return _eventService.Get(e => e.Id == eventId && e.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Event @event)
        {
            _eventService.Add(@event);
            return Ok(@event);
        }

        [HttpPut("Delete")]
        public ActionResult Delete(int eventId)
        {
            var currentEvent = _eventService.Get(e => e.Id == eventId && e.IsActive);
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
