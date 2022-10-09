using E_vent.Business.Abstract;
using E_vent.Business.Concrete;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventUserController : ControllerBase
    {
        private IEventUserService _eventUserService;

        public EventUserController()
        {
            _eventUserService = new EventUserManager(new EventUserDal());
        }

        [HttpGet("GetAll")]
        public List<EventUser> GetAll()
        {
            return _eventUserService.GetAll(e => e.IsActive);
        }

        [HttpGet("Get")]
        public EventUser Get(int eventUserId)
        {
            return _eventUserService.Get(e => e.Id == eventUserId && e.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] EventUser eventUser)
        {
            _eventUserService.Add(eventUser);
            return Ok(eventUser);
        }

        [HttpPut("Delete")]
        public ActionResult Delete(int eventUserId)
        {
            var eventUser = _eventUserService.Get(e => e.Id == eventUserId && e.IsActive);
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
