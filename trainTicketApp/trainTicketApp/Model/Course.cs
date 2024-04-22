namespace trainTicketApp.Model
{
    public class Course
    { 
        public Guid CourseID { get; set; }
        public Guid ArrivingCity { get; set; }

        public Guid LeavingCity { get; set; }

        public DateTime ArivingTime { get; set; }

        public DateTime LeavingTime { get; set; }

        public Guid TrainId { get; set; }
    }
}
