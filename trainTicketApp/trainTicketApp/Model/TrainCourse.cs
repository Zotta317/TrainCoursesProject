using Microsoft.EntityFrameworkCore;

namespace trainTicketApp.Model
{
    [Keyless]
    public class TrainCourse
    {
        public Guid SeatId { get; set; }

        public Guid CourseId { get; set; }

        public bool Booked { get; set; }
    }
}
