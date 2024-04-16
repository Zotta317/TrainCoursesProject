using Microsoft.EntityFrameworkCore;
using trainTicketApp.DTOs;
using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public interface ITicketRepository
    {
        public List<TicketGetDTO> GetTickets(Guid userID);

        //public Task<Ticket> AddTicket(Guid courseID, Guid userId);
    }
    public class TicketRepository : ITicketRepository
    {
        private readonly TrainDbContext trainDbContext;
        private readonly CourseRepository courseRepository;
        private readonly SeatRepository seatRepository;
        private readonly TrainRepository trainRepository;
        private readonly TrainCourseRepository trainCourseRepository;

        public TicketRepository(TrainDbContext _trainDbContext, CourseRepository _courseRepository, SeatRepository _seatRepository, TrainRepository _trainRepository, TrainCourseRepository _trainCourseRepository)
        {
            trainDbContext = _trainDbContext;
            courseRepository = _courseRepository;
            seatRepository = _seatRepository;
            trainRepository = _trainRepository;
            trainCourseRepository = _trainCourseRepository;
        }

        public async Task<Ticket> AddTicket(Guid courseID, Guid userId)
        {
            var course = courseRepository.GetCourse(courseID);
            var train = trainRepository.GetTrainById(course.TrainId);
            var carrige = trainDbContext.Carrige.FirstOrDefault(c => c.TrainId == course.TrainId).CarrigeID;
            var seatId = await trainCourseRepository.UpdateTrainCourseSeat(courseID);

            var ticket = new Ticket
            {
                TicketID = Guid.NewGuid(),
                ProfileId = userId,
                TrainId = course.TrainId,
                SeatId = seatId,
                CourseId = courseID,

            };

            await trainDbContext.Ticket.AddAsync(ticket);

            course.NumberOfSeatsAvailable = trainCourseRepository.GetAvailableSeats(courseID);
            await trainDbContext.SaveChangesAsync();

            return ticket;

        }

        public List<TicketGetDTO> GetTickets(Guid userID)
        {
            
            var user = trainDbContext.User.FirstOrDefault(x => x.ID == userID);

            var ticketDtos = (
                from ticket in trainDbContext.Ticket
                join course in trainDbContext.Course on ticket.CourseId equals course.CourseID
                join train in trainDbContext.Train on ticket.TrainId equals train.TrainID
                join seat in trainDbContext.Seat on ticket.SeatId equals seat.SeatID
                join carrige in trainDbContext.Carrige on seat.CarrigeId equals carrige.CarrigeID
                select new TicketGetDTO
                {
                    TicketID = ticket.TicketID,
                    TrainName = train.TrainName,
                    CarrigeName = carrige.Name,
                    SeatName = seat.SeatName,
                    ArrivingCity = course.ArrivingCity.ToString(),
                    LeavingCity = course.LeavingCity.ToString(),
                    ArrivingTime = course.ArivingTime,
                    LeavingTime = course.LeavingTime,
                    ClientName = $"{user.FirstName} {user.LastName}"
                }
            ).ToList();

            //foreach (var ticket in tickets)
            //{
            //    var course = courseRepository.GetCourse(ticket.CourseId);
            //    var seat = seatRepository.GetBySeatId(ticket.SeatId);
            //    var train = trainRepository.GetTrainName(ticket.TrainId);

            //    var ticketDTO = new TicketGetDTO
            //    {
            //        TicketID = ticket.TicketID,
            //        TrainName = train,
            //        CarrigeName = trainDbContext.Carrige.FirstOrDefault(c => c.CarrigeID == seat.CarrigeId).Name,
            //        SeatName = seat.SeatName,
            //        ArrivingCity = course.ArrivingCity.ToString(),
            //        LeavingCity = course.LeavingCity.ToString(),
            //        ArrivingTime = course.ArivingTime,
            //        LeavingTime = course.ArivingTime,
            //        ClientName = user.FirstName + " " + user.LastName,
            //    };

            //    ticketDtos.Add(ticketDTO);

            //}

            return ticketDtos;
        }


    }
}
