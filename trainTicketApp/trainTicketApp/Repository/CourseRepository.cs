using trainTicketApp.DTOs;
using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public interface ICourseRepository
    {
        public List<CourseGetDTO> GetAllCourses();
        public List<CourseGetDTO> GetCoursesByDate(DateTime selectedDate);
        public Course GetCourseById(Guid courseId);
        public Task<Course> AddCourse(CourseAddDTO course);
    }
    public class CourseRepository : ICourseRepository
    {
        private readonly TrainDbContext trainDbContext;
        private readonly TrainRepository _trainRepository;
        private readonly TrainCourseRepository _trainCourseRepository;
        private readonly PlatformRepository _platformRepository;


        public CourseRepository(TrainDbContext context, TrainRepository trainRepository, TrainCourseRepository trainCourseRepository, PlatformRepository platformRepository)
        {
            trainDbContext = context;
            _trainRepository = trainRepository;
            _trainCourseRepository = trainCourseRepository;
            _platformRepository = platformRepository;
        }

        public List<CourseGetDTO> GetAllCourses()
        {
            var courses = trainDbContext.Course.Where(c => c.LeavingTime >= DateTime.Now).ToList();
            var courseDtos = new List<CourseGetDTO>();

            foreach (var course in courses)
            {
                var trainName = _trainRepository.GetTrainName(course.TrainId);
                var availableSeats = _trainCourseRepository.GetAvailableSeats(course.CourseID);
                var LCity = _platformRepository.GetPlatformCity(course.LeavingCity);
                var ACity = _platformRepository.GetPlatformCity(course.ArrivingCity);
                var courseDto = new CourseGetDTO
                {
                    CourseID = course.CourseID,
                    LeavingCity = LCity,
                    ArrivingCity = ACity,
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

                var LCity = _platformRepository.GetPlatformCity(course.LeavingCity);
                var ACity = _platformRepository.GetPlatformCity(course.ArrivingCity);
                var courseDto = new CourseGetDTO
                {
                    CourseID = course.CourseID,
                    LeavingCity = LCity,
                    ArrivingCity = ACity,
                    LeavingTime = course.LeavingTime,
                    ArivingTime = course.ArivingTime,
                    NumberOfSeatsAvailable = availableSeats,
                    TrainName = trainName
                };

                courseDtos.Add(courseDto);
            }

            return courseDtos;
        }

        public Course GetCourseById(Guid id)
        {
            return trainDbContext.Course.FirstOrDefault(c => c.CourseID == id);
        }

        public async Task<Course> AddCourse(CourseAddDTO course)
        {
            var courseToAdd = new Course
            {
                CourseID = new Guid(),
                LeavingCity = course.LeavingCity,
                ArrivingCity = course.ArrivingCity,
                LeavingTime = course.LeavingTime,
                ArivingTime = course.ArivingTime,
                TrainId = course.TrainId,
            };

            await trainDbContext.Course.AddAsync(courseToAdd);
            await _trainCourseRepository.AddTrainCoursesSeats(courseToAdd);
            await trainDbContext.SaveChangesAsync();
            return courseToAdd;
        } 
    }
}
