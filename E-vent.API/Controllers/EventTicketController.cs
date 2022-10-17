using E_vent.API.Helpers.Attributes;
using E_vent.Business.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class EventTicketController : ControllerBase
    {
        private IEventTicketService _eventTicketService;

        public EventTicketController(IEventTicketService eventTicketService)
        {
            _eventTicketService = eventTicketService;
        }

        [HttpGet("GetAll")]
        public List<EventTicket> GetAll()
        {
            return _eventTicketService.GetAll(e => e.IsActive);
        }

        [HttpGet("GetAll/{id}")]
        public List<EventTicket> GetAll(int id)
        {
            return _eventTicketService.GetAll(e => e.IsActive && e.EventId==id);
        }

        [HttpGet("Get/{id}")]
        public EventTicket Get(int id)
        {
            return _eventTicketService.Get(e => e.Id == id && e.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] EventTicket eventTicket)
        {
                _eventTicketService.Add(eventTicket);
                return Ok(eventTicket);
        }

        [HttpPatch("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var eventTicket = _eventTicketService.Get(e => e.Id == id && e.IsActive);
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
