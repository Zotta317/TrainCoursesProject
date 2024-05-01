using trainTicketApp.Data;
using trainTicketApp.DTOs;
using trainTicketApp.Model;

namespace trainTicketApp.Repository
{
    public class CourseSeatsRepository
    {
        private readonly TraintDataApi.TrainDbContext _trainDbContext;

        public CourseSeatsRepository(TraintDataApi.TrainDbContext trainDbContext)
        {
            _trainDbContext = trainDbContext;
        }

        public async Task<Guid> UpdateTrainCourseSeat(Guid courseId)
        {
            var seat = _trainDbContext.CourseSeats
                .FirstOrDefault(tc => tc.CourseId == courseId && tc.Booked == false);
            seat.Booked = true;

            await _trainDbContext.SaveChangesAsync();
            return seat.SeatId;
        }

        public int GetAvailableSeats(Guid courseId)
        {
            return _trainDbContext.CourseSeats
                .Where(tc => tc.CourseId == courseId && tc.Booked == false)
                .ToList()
                .Count();
        }

        public async Task AddCourseSeats(TrainCourse course)
        {

            var seats = _trainDbContext.Seat.Where(s => s.TrainId == course.TrainId).ToList();
            var courseSeats = seats.Select(seat => new CourseSeats
            {
                CourseId = course.CourseId,
                SeatId = seat.SeatID,
                Booked = false
            }).ToList();

            await _trainDbContext.CourseSeats.AddRangeAsync(courseSeats);
        }


    }
}
