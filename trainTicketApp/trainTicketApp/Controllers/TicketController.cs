using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trainTicketApp.Data;
using trainTicketApp.Framework.Identity;
using trainTicketApp.Model;
using trainTicketApp.ModelView;

namespace trainTicketApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly TraintDataApi.TrainDbContext trainDbContext;

        public TicketController(TraintDataApi.TrainDbContext dbContext)
        {
            trainDbContext = dbContext;
        }

        [HttpGet("GetAllTickets")]
        public async Task<Ticket[]> ListTickets()
        {
            return await trainDbContext.Ticket.ToArrayAsync();
        }



        [HttpPost("AddTicket")]
        public async Task<IActionResult> PostTicket(Guid courseId)
        {
            Identity identity = ControllerContext.GetIdentity();

            var course = await trainDbContext.Course.FirstOrDefaultAsync(c => c.CourseID == courseId);

            var train = await trainDbContext.Train.FirstOrDefaultAsync(t => t.TrainID == course.TrainId);

            if (train != null)
            {
                var seat = trainDbContext.Seat.FirstOrDefault(s => s.CourseId == courseId && s.Booked == false);

                if (seat != null)
                {

                    var ticket = new Ticket
                    {
                        TicketID = Guid.NewGuid(),
                        ProfileId = identity.ID,
                        TrainId = seat.TrainId,
                        CarrigeId = seat.CarrigeId,
                        SeatId = seat.SeatID,
                        CourseId = courseId,
                        ArrivalTime = course.ArivingTime,
                        LeavingTime = course.LeavingTime,
                        ArrivingCity = course.ArrivingCity,
                        LeavingCity = course.LeavingCity,
                        PlatformId = course.PlatformId,

                    };

                    trainDbContext.Ticket.Add(ticket);

                    seat.Booked = true;

                     await trainDbContext.SaveChangesAsync();

                    return NoContent();
            } else
                {
                    return NotFound("Seat not found.");

                }

            } else
            {
                return NotFound("Seat not found.");
            }
        }


        [HttpGet("AllUserTickets")]
        public IActionResult GetUserTickets()
        {
            Identity identity = ControllerContext.GetIdentity();

            Profile user = trainDbContext.User.FirstOrDefault(x => x.ID == identity.ID);

            var tickets = trainDbContext.Ticket.Where(r => r.ProfileId == identity.ID).Select(t => new TicketView

            {
                TicketID = t.TicketID,
                TrainName = trainDbContext.Train.FirstOrDefault(x => x.TrainID == t.TrainId).TrainName,
                CarrigeName = trainDbContext.Carrige.FirstOrDefault(x => x.CarrigeID == t.CarrigeId).Name,
                SeatName = trainDbContext.Seat.FirstOrDefault(x => x.SeatID == t.SeatId).SeatName,
                ArrivingTime = t.ArrivalTime,
                LeavingTime = t.LeavingTime,
                ArrivingCity = t.ArrivingCity,
                LeavingCity = t.LeavingCity,
                LastName = user.LastName,
                FirstName = user.FirstName,

            }).ToList();

            return Ok(tickets);
        }
       
    }
}
