namespace trainTicketApp.Model
{
    public class TrainCourse
    {
        public Guid TrainId { get; set; }
        public Guid CourseId { get; set; }

        public Guid ArrivingCity { get; set; }

        public Guid Leavingcity { get; set; }

        public DateTime ArrivingDate { get; set; }

        public DateTime LeavingDate { get; set;}

        public int AvaillableSeats { get; set; }
    }
}
