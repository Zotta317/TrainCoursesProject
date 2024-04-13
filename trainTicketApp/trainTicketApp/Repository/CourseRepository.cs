using trainTicketApp.DTOs;
using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public interface ICourseRepository
    {
        public List<CourseGetDTO> GetCourses();
        public Course GetCourse(Guid courseId);
        public  Task<Course> AddCourse(CourseAddDTO course); 
    }
    public class CourseRepository : ICourseRepository
    {
        private readonly TrainDbContext trainDbContext;
        private readonly TrainRepository _trainRepository;

        public CourseRepository(TrainDbContext context, TrainRepository trainRepository)
        {
            trainDbContext = context;
            _trainRepository = trainRepository;
        }

        public List<CourseGetDTO> GetCourses()
        {
            var courses = trainDbContext.Course.ToList();
            var courseDtos = new List<CourseGetDTO>();

            foreach (var course in courses)
            {
                var trainName = _trainRepository.GetTrainName(course.TrainId);
                var courseDto = new CourseGetDTO
                {
                    CourseID = course.CourseID,
                    LeavingCity = course.LeavingCity,
                    ArrivingCity = course.ArrivingCity,
                    LeavingTime = course.LeavingTime,
                    ArivingTime = course.ArivingTime,
                    NumberOfSeatsAvailable = course.NumberOfSeatsAvailable,
                    TrainName = trainName
                };

                courseDtos.Add(courseDto);
            }

            return courseDtos;
        }

        public  Course GetCourse(Guid id)
        {
            return trainDbContext.Course.FirstOrDefault(c => c.CourseID == id);
        }

        public async Task<Course> AddCourse(CourseAddDTO course)
        {
            var availableSeats = trainDbContext.Train.FirstOrDefault(t => t.TrainID == course.TrainId).NumberOfSeats;
            var courseToAdd = new Course
            {
                CourseID = new Guid(),
                LeavingCity = course.LeavingCity,
                ArrivingCity = course.ArrivingCity,
                LeavingTime = course.LeavingTime,
                ArivingTime = course.ArivingTime,
                NumberOfSeatsAvailable = availableSeats,
                TrainId = course.TrainId,
            };

            await trainDbContext.Course.AddAsync(courseToAdd);
            await trainDbContext.SaveChangesAsync();
            return courseToAdd;
        } 
    }
}
