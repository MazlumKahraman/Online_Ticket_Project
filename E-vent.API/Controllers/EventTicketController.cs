using E_vent.Business.Abstract;
using E_vent.Business.Concrete;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTicketController : ControllerBase
    {
        private IEventTicketService _eventTicketService;

        public EventTicketController()
        {
            _eventTicketService = new EventTicketManager(new EventTicketDal());
        }

        [HttpGet("GetAll")]
        public List<EventTicket> GetAll()
        {
            return _eventTicketService.GetAll(e => e.IsActive);
        }

        [HttpGet("Get")]
        public EventTicket Get(int eventTicketId)
        {
            return _eventTicketService.Get(e => e.Id == eventTicketId && e.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] EventTicket eventTicket)
        {
                _eventTicketService.Add(eventTicket);
                return Ok(eventTicket);
        }

        [HttpPut("Delete")]
        public ActionResult Delete(int eventTicketId)
        {
            var eventTicket = _eventTicketService.Get(e => e.Id == eventTicketId && e.IsActive);
            if (eventTicket is not null)
            {
                eventTicket.IsActive = false;
                _eventTicketService.Update(eventTicket);
                return NoContent();
            }
            return BadRequest("EventTicket not found");
        }

        [HttpPut("Update")]
        public ActionResult Update(EventTicket eventTicket)
        {
            var updateEventTicket = _eventTicketService.Get(e => e.Id == eventTicket.Id && e.IsActive);
            if (updateEventTicket is not null)
            {
                _eventTicketService.Update(eventTicket);
                return Ok(eventTicket);
            }
            return BadRequest("EventTicket not found");
        }
    }
}
