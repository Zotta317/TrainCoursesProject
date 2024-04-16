namespace trainTicketApp.Model
{
    public class Ticket
    {
        public Guid TicketID { get; set; }

        public Guid? ProfileId { get; set; }

        public Guid TrainId { get; set; }

        public Guid SeatId { get; set; }
        public Guid CourseId { get; set; }

    }
}
