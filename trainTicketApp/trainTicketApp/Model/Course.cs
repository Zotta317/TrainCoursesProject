namespace trainTicketApp.Model
{
    public class Course
    {
        
        public Guid CourseID { get; set; }

        public Guid PlatformId { get; set; }
        public string ArrivingCity { get; set; }

        public string LeavingCity { get; set; }

        public DateTime ArivingTime { get; set; }

        public DateTime LeavingTime { get; set; }

        public int NumberOfSeatsAvailable { get; set; }

        public Guid TrainId { get; set; }
    }
}
