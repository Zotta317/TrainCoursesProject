using trainTicketApp.DTOs;
using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public interface ICourseRepository
    {
        public List<CourseGetDTO> GetCourses();
        public List<CourseGetDTO> GetCoursesByDate(DateTime selectedDate);
        public Course GetCourse(Guid courseId);
        public  Task<Course> AddCourse(CourseAddDTO course); 
    }
    public class CourseRepository : ICourseRepository
    {
        private readonly TrainDbContext trainDbContext;
        private readonly TrainRepository _trainRepository;
        private readonly TrainCourseRepository _trainCourseRepository;

        public CourseRepository(TrainDbContext context, TrainRepository trainRepository, TrainCourseRepository trainCourseRepository)
        {
            trainDbContext = context;
            _trainRepository = trainRepository;
            _trainCourseRepository = trainCourseRepository;
        }

        public List<CourseGetDTO> GetCourses()
        {
            var courses = trainDbContext.Course.Where(c => c.LeavingTime >= DateTime.Now).ToList();
            var courseDtos = new List<CourseGetDTO>();

            foreach (var course in courses)
            {
                var trainName = _trainRepository.GetTrainName(course.TrainId);
                var availableSeats = _trainCourseRepository.GetAvailableSeats(course.CourseID);
                var courseDto = new CourseGetDTO
                {
                    CourseID = course.CourseID,
                    LeavingCity = course.LeavingCity,
                    ArrivingCity = course.ArrivingCity,
                    LeavingTime = course.LeavingTime,
                    ArivingTime = course.ArivingTime,
                    NumberOfSeatsAvailable = availableSeats,
                    TrainName = trainName
                };

                courseDtos.Add(courseDto);
            }

            return courseDtos;
        }

        public List<CourseGetDTO> GetCoursesByDate(DateTime selectedDate)
        {
            var courses = trainDbContext.Course.Where(c => c.LeavingTime.Date == selectedDate.Date).ToList();
            var courseDtos = new List<CourseGetDTO>();

            foreach (var course in courses)
            {
                var trainName = _trainRepository.GetTrainName(course.TrainId);
                var availableSeats = _trainCourseRepository.GetAvailableSeats(course.CourseID);
                var courseDto = new CourseGetDTO
                {
                    CourseID = course.CourseID,
                    LeavingCity = course.LeavingCity,
                    ArrivingCity = course.ArrivingCity,
                    LeavingTime = course.LeavingTime,
                    ArivingTime = course.ArivingTime,
                    NumberOfSeatsAvailable = availableSeats,
                    TrainName = trainName
                };

                courseDtos.Add(courseDto);
            }

            return courseDtos;
        }

        public Course GetCourse(Guid id)
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
            await _trainCourseRepository.CreateTrainCoursesSeats(courseToAdd);
            await trainDbContext.SaveChangesAsync();
            return courseToAdd;
        } 
    }
}
