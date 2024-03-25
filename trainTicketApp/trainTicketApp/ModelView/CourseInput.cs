namespace trainTicketApp.ModelView
{
    public class CourseInput
    {
        public string ArrivingCity { get; set; }

        public string LeavingCity { get; set; }

        public DateTime ArivingTime { get; set; }

        public DateTime LeavingTime { get; set; }
        public string TrainName { get; set;}

        public Guid PlatformId { get; set; }
    }
}
