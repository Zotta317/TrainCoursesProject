namespace trainTicketApp.ModelView
{
    public class TicketView
    {
        public Guid TicketID { get; set; }
        public string TrainName { get; set; }

        public string CarrigeName { get; set; }

        public string SeatName { get; set; }

        public DateTime LeavingTime { get; set; }

        public DateTime ArrivingTime { get; set; }

        public string LeavingCity { get; set; }

        public string ArrivingCity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
