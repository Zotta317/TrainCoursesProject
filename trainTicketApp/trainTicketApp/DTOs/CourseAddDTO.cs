namespace trainTicketApp.DTOs
{
    public class CourseAddDTO
    {
        public Guid ArrivingCity { get; set; }

        public Guid LeavingCity { get; set; }

        public DateTime ArivingTime { get; set; }

        public DateTime LeavingTime { get; set; }
        public Guid TrainId { get; set; }
    }
}
