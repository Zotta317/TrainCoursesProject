namespace trainTicketApp.Model
{
    public class Carrige
    {
        public Guid CarrigeID { get; set; }

        public string? Name { get; set; }

        public Guid TrainId { get; set; }

        public int AvailableSeats { get; set; }

        public Guid CourseId { get; set; }

    }
}
