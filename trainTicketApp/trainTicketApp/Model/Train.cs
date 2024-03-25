namespace trainTicketApp.Model
{
    public enum TrainCategories
    {
        Highspeed,
        TouristTrains,
        CommuterTrains,
        Railcar
    }

    public class Train
    {
        public Guid TrainID { get; set; }

        public string TrainName { get; set; }

        public TrainCategories TrainType { get; set; }

        public int NumberOfSeats { get; set; }
    }
}
