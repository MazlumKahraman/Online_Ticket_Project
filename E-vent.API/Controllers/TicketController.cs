using E_vent.Business.Abstract;
using E_vent.Business.Concrete;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;

        public TicketController()
        {
            _ticketService = new TicketManager(new TicketDal());
        }

        [HttpGet("GetAll")]
        public List<Ticket> GetAll()
        {
            return _ticketService.GetAll(t => t.IsActive);
        }

        [HttpGet("Get")]
        public Ticket Get(int ticketId)
        {
            return _ticketService.Get(t => t.Id == ticketId && t.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Ticket ticket)
        {
            _ticketService.Add(ticket);
            return Ok(ticket);
        }

        [HttpPut("Delete")]
        public ActionResult Delete(int ticketId)
        {
            var ticket = _ticketService.Get(t => t.Id == ticketId && t.IsActive);
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
