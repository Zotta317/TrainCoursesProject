using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public class SeatRepository
    {
        private readonly TrainDbContext _trainDbContext;

        public SeatRepository(TrainDbContext trainDbContext)
        {
            _trainDbContext = trainDbContext;
        }

        public List<Seat> GetAllSeats()
        {
            return _trainDbContext.Seat.ToList();
        }

        public Seat GetBySeatId(Guid seatId)
        {
            return _trainDbContext.Seat.FirstOrDefault(s => s.SeatID == seatId);
        }

        public string GetSeatName(Guid seatId)
        {
            return _trainDbContext.Seat.FirstOrDefault(s => s.SeatID == seatId).SeatName;
        }
    }
}
