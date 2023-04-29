using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketEntry.API.Data;
using TicketEntry.Shared.DTOs;

namespace TicketEntry.API.Controllers
{
    [ApiController]
    [Route("/api/ticket")]
    public class TicketController : ControllerBase
    {
        private readonly DataContext _context;
        public TicketController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var TicketFind = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            if (TicketFind == null)
            {
                return BadRequest("Boleta no valida");
            }

            if (TicketFind.Used == true)
            {
                return BadRequest("La boleta ya fue utilizada");
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(TicketDTO ticketDTO)
        {

            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == ticketDTO.Id);
            if (ticket == null)
            {
                return BadRequest("Error al actualizar");
            }
            ticket.Id = ticketDTO.Id;
            ticket.UseDate = ticketDTO.UseDate;
            ticket.Used = ticketDTO.Used;
            ticket.Entrance = ticketDTO.Entrance;

            _context.Update(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);
        }
    }
}
