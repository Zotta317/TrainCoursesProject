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
        //public async Task<Ticket[]> ListTickets()
        //{
        //    return await trainDbContext.Ticket.ToArrayAsync();
        //}



        [HttpPost("AddTicket")]
        public async Task<IActionResult> PostTicket(Guid courseId)
        {
            Guid userID = ControllerContext.GetIdentity().ID;
            var ticket = await _ticketService.AddTicket(courseId, userID);
            return CreatedAtAction(nameof(PostTicket), ticket);

        }
        //{
        //    ;

        //    var course = await trainDbContext.Course.FirstOrDefaultAsync(c => c.CourseID == courseId);

        //    var train = await trainDbContext.Train.FirstOrDefaultAsync(t => t.TrainID == course.TrainId);

        //    if (train != null)
        //    {
        //        var seat = trainDbContext.Seat.FirstOrDefault(s => s.CourseId == courseId && s.Booked == false);

        //        if (seat != null)
        //        {

        //            var ticket = new Ticket
        //            {
        //                TicketID = Guid.NewGuid(),
        //                ProfileId = identity.ID,
        //                TrainId = seat.TrainId,
        //                CarrigeId = seat.CarrigeId,
        //                SeatId = seat.SeatID,
        //                CourseId = courseId,
        //                ArrivalTime = course.ArivingTime,
        //                LeavingTime = course.LeavingTime,
        //                ArrivingCity = course.ArrivingCity,
        //                LeavingCity = course.LeavingCity,
        //                PlatformId = course.PlatformId,

        //            };

        //            trainDbContext.Ticket.Add(ticket);

        //            seat.Booked = true;

        //            await trainDbContext.SaveChangesAsync();

        //            return NoContent();
        //    } else
        //        {
        //            return NotFound("Seat not found.");

        //        }

        //    } else
        //    {
        //        return NotFound("Seat not found.");
        //    }
        //}


        //[HttpGet("AllUserTickets")]
        //public IActionResult GetUserTickets()
        //{
        //    Identity identity = ControllerContext.GetIdentity();

        //    Profile user = trainDbContext.User.FirstOrDefault(x => x.ID == identity.ID);

        //    //Avoid Repeated Query on table(train/seat/carrige) for each ticket
        //    var tickets = (
        //        from ticket in trainDbContext.Ticket
        //        join train in trainDbContext.Train on ticket.TrainId equals train.TrainID
        //        join carrige in trainDbContext.Carrige on ticket.CarrigeId equals carrige.CarrigeID
        //        join seat in trainDbContext.Seat on ticket.SeatId equals seat.SeatID
        //        where ticket.ProfileId == identity.ID
        //        select new TicketView
        //        {
        //            TicketID = ticket.TicketID,
        //            TrainName = train.TrainName,
        //            CarrigeName = carrige.Name,
        //            SeatName = seat.SeatName,
        //            ArrivingTime = ticket.ArrivalTime,
        //            LeavingTime = ticket.LeavingTime,
        //            ArrivingCity = ticket.ArrivingCity,
        //            LeavingCity = ticket.LeavingCity,
        //            LastName = user.LastName,
        //            FirstName = user.FirstName
        //        }).ToList();



        //    //var tickets = trainDbContext.Ticket.Where(r => r.ProfileId == identity.ID).Select(t => new TicketView

        //    //{
        //    //    TicketID = t.TicketID,
        //    //    TrainName = trainDbContext.Train.FirstOrDefault(x => x.TrainID == t.TrainId).TrainName,
        //    //    CarrigeName = trainDbContext.Carrige.FirstOrDefault(x => x.CarrigeID == t.CarrigeId).Name,
        //    //    SeatName = trainDbContext.Seat.FirstOrDefault(x => x.SeatID == t.SeatId).SeatName,
        //    //    ArrivingTime = t.ArrivalTime,
        //    //    LeavingTime = t.LeavingTime,
        //    //    ArrivingCity = t.ArrivingCity,
        //    //    LeavingCity = t.LeavingCity,
        //    //    LastName = user.LastName,
        //    //    FirstName = user.FirstName,

        //    //}).ToList();

        //    return Ok(tickets);
        //}

    }
}
