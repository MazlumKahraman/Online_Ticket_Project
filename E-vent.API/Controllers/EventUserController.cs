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
            return _eventUserService.GetAll(e => e.IsActive == true);
        }
        [HttpGet("GetJoined/{id}")]
        public List<EventUser> GetJoined(int id)
        {
            return _eventUserService.GetAll(e => e.IsActive == true && e.UserId==id && e.Event.BegginigTime<DateTime.Now);
        }
        [HttpGet("GetNextJoins/{id}")]
        public List<EventUser> GetNextJoins(int id)
        {
            return _eventUserService.GetAll(e => e.IsActive == true && e.UserId == id && e.Event.BegginigTime >= DateTime.Now);
        }
        [HttpGet("Get/{eventId}/{userId}")]
        public EventUser Get(int eventId, int userId)
        {
            var model = _eventUserService.Get(e => e.EventId == eventId && e.UserId == userId && e.IsActive == true);
            return model ;
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] EventUser eventUser)
        {
            eventUser.IsActive = true;
            _eventUserService.Add(eventUser);
            return Ok(eventUser);
        }

        [HttpPatch("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var eventUser = _eventUserService.Get(e => e.Id == id && e.IsActive==true);
            if (eventUser is not null)
            {
                eventUser.IsActive = false;
                _eventUserService.Update(eventUser);
                return NoContent();
            }
            return BadRequest("EventUser not found");
        }
        
        [HttpPatch("Update/{id}")]
        public ActionResult Update(int id)
        {
            var updateEventUser = _eventUserService.Get(e => e.Id == id && e.IsActive == true);
            if (updateEventUser is not null)
            {
                updateEventUser.IsCancelled = true;
                updateEventUser.IsActive = false;
                _eventUserService.Update(updateEventUser);
                return Ok(updateEventUser);
            }
            return BadRequest("EventUser not found");
        }
    }
}
