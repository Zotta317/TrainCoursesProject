namespace trainTicketApp.Model
{
    public class TrainCourse
    {
        public Guid TrainCourseID {  get; set; }

        public Guid TrainId { get; set; }

        public Guid CourseId { get; set; }

        public int availableSeats { get; set; }
    }
}
