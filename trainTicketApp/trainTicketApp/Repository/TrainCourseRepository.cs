using trainTicketApp.Data;
using trainTicketApp.Migrations;
using trainTicketApp.Model;

namespace trainTicketApp.Repository
{
    public class TrainCourseRepository
    {
        private readonly TraintDataApi.TrainDbContext trainDbContext;

        public TrainCourseRepository(TraintDataApi.TrainDbContext trainDbContext)
        {
            this.trainDbContext = trainDbContext;
        }

        public async Task AddTrainCoursesSeats(Course course)
        {
            var seats = trainDbContext.Seat.Where(s => s.TrainId == course.TrainId).ToList();
            var trainCourses = seats.Select(seat => new TrainCourse
            {
                CourseId = course.CourseID,
                SeatId = seat.SeatID,
                Booked = false
            }).ToList();

            await trainDbContext.TrainCourses.AddRangeAsync(trainCourses);
        }

        public async Task<Guid> UpdateTrainCourseSeat(Guid courseId)
        {
            var seat = trainDbContext.TrainCourses.FirstOrDefault(tc => tc.CourseId == courseId && tc.Booked == false);
            seat.Booked = true;

            await trainDbContext.SaveChangesAsync();
            return seat.SeatId;
        }

        public int GetAvailableSeats(Guid courseId)
        {
            return trainDbContext.TrainCourses
                .Where(tc => tc.CourseId == courseId && tc.Booked == false)
                .ToList()
                .Count();
        }

    }
}
