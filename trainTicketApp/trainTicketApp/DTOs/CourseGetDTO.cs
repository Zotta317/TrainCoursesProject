namespace trainTicketApp.DTOs
{
    public class CourseGetDTO
    {
        public Guid CourseID { get; set; }
        public string ArrivingCity { get; set; }

        public string LeavingCity { get; set; }

        public DateTime ArivingTime { get; set; }

        public DateTime LeavingTime { get; set; }

        public int NumberOfSeatsAvailable { get; set; }

        public string TrainName { get; set; }
    }
}
