using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trainTicketApp.DTOs;
using trainTicketApp.Framework.Identity;
using trainTicketApp.Service;

namespace trainTicketApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("GetAllTickets")]
        public ActionResult<List<TicketGetDTO>> GetTickets()
        {
            Guid userID = ControllerContext.GetIdentity().ID;
            return _ticketService.GetTickets(userID);
        }

        [HttpPost("AddTicket")]
        public async Task<IActionResult> PostTicket(Guid courseId)
        {
            Guid userID = ControllerContext.GetIdentity().ID;
            var ticket = await _ticketService.AddTicket(courseId, userID);
            return CreatedAtAction(nameof(PostTicket), ticket);

        }
    }
}
