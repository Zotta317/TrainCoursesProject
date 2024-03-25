using trainTicketApp.Model;

namespace trainTicketApp.ModelView
{
    public class CourseView
    {
        public Guid CourseID { get; set; }
        public string LeavingCity { get; set; }

        public string ArrivingCity { get; set; }

        public DateTime LeavingTime { get; set; }

        public DateTime ArrivingTime { get; set; }

        public int AvailableTrainSeats { get; set; }

        public string TrainName { get; set; }

        public TrainCategories TrainType { get; set; }

    }
}
