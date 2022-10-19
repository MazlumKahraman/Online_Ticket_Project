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
        public List<Event> GetAll(int? navigate)
        {
            return (navigate is null)
                ? _eventService.GetAll(e => e.IsActive == true && e.BegginigTime>DateTime.Now)
                : _eventService.GetAll(e => e.IsActive == true && e.BegginigTime > DateTime.Now, true);
        }
        [HttpGet("GetAll/{id}")]//apihelper.get<List<EventViewDto>>($"event/getall/{currentuser.id}?navigate=1")
        public List<Event> GetAll(int id, int? navigate)
        {
            return (navigate is null)
                ? _eventService.GetAll(e => e.IsActive == true && e.UserId == id)
                : _eventService.GetAll(e => e.IsActive == true && e.UserId == id, true);
        }

        [HttpGet("Get/{id}")]
        public Event Get(int id, int? navigate)
        {
            return (navigate is null)
                ? _eventService.Get(e => e.Id == id && e.IsActive == true && e.BegginigTime > DateTime.Now)
                : _eventService.Get(e => e.Id == id && e.IsActive == true && e.BegginigTime > DateTime.Now, true) ;
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Event @event)
        {
            _eventService.Add(@event);
            return Ok(@event);
        }

        [HttpPatch("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var currentEvent = _eventService.Get(e => e.Id == id && e.IsActive == true);
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
            var updateEvent = _eventService.Get(e => e.Id == @event.Id && e.IsActive == true);
            if (updateEvent is not null)
            {
                updateEvent.Quato = @event.Quato;
                updateEvent.Adress = @event.Adress;
                _eventService.Update(updateEvent);
                return Ok(updateEvent);
            }
            return BadRequest("Event not found");
        }

        [HttpPatch("Approve/{id}")]
        public ActionResult Approve(int id)
        {
            var updateEvent = _eventService.Get(e => e.Id == id && e.IsActive == true);
            if (updateEvent is not null)
            {
                updateEvent.StatusId = 2;
                _eventService.Update(updateEvent);
                return Ok(updateEvent);
            }
            return BadRequest("Event not found");
        }
        [HttpPatch("Decline/{id}")]
        public ActionResult Decline(int id)
        {
            var updateEvent = _eventService.Get(e => e.Id == id && e.IsActive == true);
            if (updateEvent is not null)
            {
                updateEvent.StatusId = 3;
                _eventService.Update(updateEvent);
                return Ok(updateEvent);
            }
            return BadRequest("Event not found");
        }
    }
}
