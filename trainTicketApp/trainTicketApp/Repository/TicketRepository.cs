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
        private readonly TrainDbContext _trainDbContext;
        private readonly TrainCourseRepository _trainCourseRepository;
        private readonly SeatRepository _seatRepository;
        private readonly TrainRepository _trainRepository;
        private readonly CourseSeatsRepository _courseSeatsRepository;
        private readonly CarrigeRepository _carrigeRepository;
        private readonly ProfileRepository _profileRepository;
        private readonly PlatformRepository _platformRepository;

        public TicketRepository(TrainDbContext trainDbContext, TrainCourseRepository trainCourseRepository, SeatRepository seatRepository, 
            TrainRepository trainRepository, CourseSeatsRepository courseSeatsRepository, CarrigeRepository carrigeRepository,
            ProfileRepository profileRepository,PlatformRepository platformRepository)
        {
            _trainDbContext = trainDbContext;
            _trainCourseRepository = trainCourseRepository;
            _seatRepository = seatRepository;
            _trainRepository = trainRepository;
            _courseSeatsRepository = courseSeatsRepository;
            _carrigeRepository = carrigeRepository;
            _profileRepository = profileRepository;
            _platformRepository = platformRepository;
        }   

        public async Task<Ticket> AddTicket(Guid courseID, Guid userId)
        {
            var course = _trainCourseRepository.GetTrainCourseById(courseID);
            var seatId = await _courseSeatsRepository.UpdateTrainCourseSeat(courseID);
            var ticket = new Ticket
            {
                TicketID = Guid.NewGuid(),
                ProfileId = userId,
                TrainId = course.TrainId,
                SeatId = seatId,
                CourseId = courseID,
                PlatformId = course.Leavingcity,
            };

            await _trainDbContext.Ticket.AddAsync(ticket);

            await _trainDbContext.SaveChangesAsync();

            return ticket;

        }

        public List<Ticket> GetAllUserTickets(Guid userID)
        {
            return _trainDbContext.Ticket.Where(t => t.ProfileId == userID).ToList();
        }

        public List<TicketGetDTO> GetTickets(Guid userID)
        {
            var user = _profileRepository.GetProfileById(userID);

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
                var trainCourse = _trainCourseRepository.GetTrainCourseById(ticket.CourseId);
                var seat = _seatRepository.GetBySeatId(ticket.SeatId);
                var train = _trainRepository.GetTrainName(ticket.TrainId);
                var carrige = _carrigeRepository.GetCarrigeByTrain(ticket.TrainId);
                var arrivingCity = _platformRepository.GetPlatformById(trainCourse.ArrivingCity).City;
                var leavingCity = _platformRepository.GetPlatformById(trainCourse.Leavingcity).City;

                var ticketDTO = new TicketGetDTO
                {
                    TicketID = ticket.TicketID,
                    TrainName = train,
                    CarrigeName = carrige.Name,
                    SeatName = seat.SeatName,
                    ArrivingCity = arrivingCity,
                    LeavingCity =leavingCity,
                    ArrivingTime = trainCourse.ArrivingDate,
                    LeavingTime = trainCourse.LeavingDate,
                    ClientName = $"{user.FirstName} {user.LastName}",
                };

                ticketDtos.Add(ticketDTO);

            }

            return ticketDtos;
        }


    }
}
