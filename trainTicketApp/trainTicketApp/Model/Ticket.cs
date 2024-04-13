namespace trainTicketApp.Model
{
    public class Ticket
    {
        public Guid TicketID { get; set; }

        public Guid? ProfileId { get; set; }

        public Guid TrainId { get; set; }

        public Guid CarrigeId { get; set; }

        public Guid SeatId { get; set; }

        public DateTime LeavingTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public Guid CourseId { get; set; }

        public Guid PlatformId { get; set; }

        public string? LeavingCity { get; set; }

        public string? ArrivingCity { get; set; }

    }
}
