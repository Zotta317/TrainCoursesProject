namespace trainTicketApp.DTOs
{
    public class TrainCourseGetDTO
    {
        public String TrainName { get; set; }
        public Guid CourseId { get; set; }

        public DateTime AvailableDate { get; set; }

        public string ArrivingCity { get; set; }

        public string ArrivingPlatform { get; set; }

        public string LeavingCity { get; set; }

        public string LeavingPlatform { get; set;}


    }
}
