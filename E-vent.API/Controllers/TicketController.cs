using E_vent.API.Helpers.Attributes;
using E_vent.Business.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("GetAll")]
        public List<Ticket> GetAll()
        {
            return _ticketService.GetAll(t => t.IsActive);
        }

        [HttpGet("Get/{id}")]
        public Ticket Get(int id)
        {
            return _ticketService.Get(t => t.Id == id && t.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Ticket ticket)
        {
            _ticketService.Add(ticket);
            return Ok(ticket);
        }

        [HttpPatch("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var ticket = _ticketService.Get(t => t.Id == id && t.IsActive);
            if (ticket is not null)
            {
                ticket.IsActive = false;
                _ticketService.Update(ticket);
                return NoContent();
            }
            return BadRequest("Ticket not found");
        }

        [HttpPut("Update")]
        public ActionResult Update(Ticket ticket)
        {
            var updateTicket = _ticketService.Get(t => t.Id == ticket.Id && t.IsActive);
            if (updateTicket is not null)
            {
                _ticketService.Update(ticket);
                return Ok(ticket);
            }
            return BadRequest("Ticket not found");
        }
    }
}
