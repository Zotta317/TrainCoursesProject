
using trainTicketApp.DTOs;
using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public interface ITicketRepository
    {
        public List<TicketGetDTO> GetTickets(Guid userID);

        public Task<Ticket> AddTicket(Guid courseID, Guid userId);

        public List<Ticket> GetAllUserTickets(Guid userId);
    }
    public class TicketRepository : ITicketRepository
    {
        private readonly TrainDbContext trainDbContext;
        private readonly CourseRepository courseRepository;
        private readonly SeatRepository seatRepository;
        private readonly TrainRepository trainRepository;
        private readonly TrainCourseRepository trainCourseRepository;
        private readonly CarrigeRepository carrigeRepository;
        private readonly ProfileRepository profileRepository;
        private readonly PlatformRepository platformRepository;

        public TicketRepository(TrainDbContext _trainDbContext, CourseRepository _courseRepository, SeatRepository _seatRepository, 
            TrainRepository _trainRepository, TrainCourseRepository _trainCourseRepository,CarrigeRepository _carrigeRepository,
            ProfileRepository _profileRepository,PlatformRepository _platformRepository)
        {
            trainDbContext = _trainDbContext;
            courseRepository = _courseRepository;
            seatRepository = _seatRepository;
            trainRepository = _trainRepository;
            trainCourseRepository = _trainCourseRepository;
            carrigeRepository = _carrigeRepository;
            profileRepository = _profileRepository;
            platformRepository = _platformRepository;
        }

        public async Task<Ticket> AddTicket(Guid courseID, Guid userId)
        {
            var course = courseRepository.GetCourseById(courseID);
            var seatId = await trainCourseRepository.UpdateTrainCourseSeat(courseID);
            var platform = platformRepository.GetPlatformById(course.LeavingCity);
            var ticket = new Ticket
            {
                TicketID = Guid.NewGuid(),
                ProfileId = userId,
                TrainId = course.TrainId,
                SeatId = seatId,
                CourseId = courseID,
                PlatformId = platform.PlatformID
            };

            await trainDbContext.Ticket.AddAsync(ticket);

            await trainDbContext.SaveChangesAsync();

            return ticket;

        }

        public List<Ticket> GetAllUserTickets(Guid userID)
        {
            return trainDbContext.Ticket.Where(t => t.ProfileId == userID).ToList();
        }

        public List<TicketGetDTO> GetTickets(Guid userID)
        {
            var user = profileRepository.GetProfileById(userID);

            //Sql Version
            //var ticketDtos = (
            //    from ticket in trainDbContext.Ticket
            //    join course in trainDbContext.Course on ticket.CourseId equals course.CourseID
            //    join train in trainDbContext.Train on ticket.TrainId equals train.TrainID
            //    join seat in trainDbContext.Seat on ticket.SeatId equals seat.SeatID
            //    join carrige in trainDbContext.Carrige on seat.CarrigeId equals carrige.CarrigeID
            //    select new TicketGetDTO
            //    {
            //        TicketID = ticket.TicketID,
            //        TrainName = train.TrainName,
            //        CarrigeName = carrige.Name,
            //        SeatName = seat.SeatName,
            //        ArrivingCity = course.ArrivingCity.ToString(),
            //        LeavingCity = course.LeavingCity.ToString(),
            //        ArrivingTime = course.ArivingTime,
            //        LeavingTime = course.LeavingTime,
            //        ClientName = $"{user.FirstName} {user.LastName}"
            //    }
            //).ToList();

            //Dotnet version

            List<TicketGetDTO> ticketDtos = new List<TicketGetDTO>();
            var tickets = GetAllUserTickets(userID);
            foreach (var ticket in tickets)
            {
                var course = courseRepository.GetCourseById(ticket.CourseId);
                var seat = seatRepository.GetBySeatId(ticket.SeatId);
                var train = trainRepository.GetTrainName(ticket.TrainId);
                var carrige = carrigeRepository.GetCarrigeByTrain(ticket.TrainId);
                var arrivingCity = platformRepository.GetPlatformById(course.ArrivingCity).City;
                var leavingCity = platformRepository.GetPlatformById(course.LeavingCity).City;

                var ticketDTO = new TicketGetDTO
                {
                    TicketID = ticket.TicketID,
                    TrainName = train,
                    CarrigeName = carrige.Name,
                    SeatName = seat.SeatName,
                    ArrivingCity = arrivingCity,
                    LeavingCity =leavingCity,
                    ArrivingTime = course.ArivingTime,
                    LeavingTime = course.ArivingTime,
                    ClientName = $"{user.FirstName} {user.LastName}",
                };

                ticketDtos.Add(ticketDTO);

            }

            return ticketDtos;
        }


    }
}
