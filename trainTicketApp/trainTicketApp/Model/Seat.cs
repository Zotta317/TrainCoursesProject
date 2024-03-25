namespace trainTicketApp.Model
{
    public class Seat
    {
        public Guid SeatID { get; set; }

        public string? SeatName { get; set; }

        public Guid CarrigeId { get; set; }

        public bool Booked { get; set; }

        public Guid TrainId { get; set; }

        public Guid CourseId { get; set; }
    }
}
