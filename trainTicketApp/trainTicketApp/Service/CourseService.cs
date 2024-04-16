using trainTicketApp.DTOs;
using trainTicketApp.Model;
using trainTicketApp.Repository;
using trainTicketApp.Validation;

namespace trainTicketApp.Service
{
    public interface ICourseService
    {
        List<CourseGetDTO> GetCourses();
        Course GetCourse(Guid courseId);

        List<CourseGetDTO> GetCoursesByDate(DateTime date);

        Task<Course> AddCourse(CourseAddDTO course);
    }
    public class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;
        private readonly TrainCourseRepository _trainCourseRepository;

        public CourseService(CourseRepository courseRepository, TrainCourseRepository trainCourseRepository)
        {
            _courseRepository = courseRepository;
            _trainCourseRepository = trainCourseRepository;
        }

        public List<CourseGetDTO> GetCourses()
        {
            return _courseRepository.GetCourses();
        }

        public List<CourseGetDTO> GetCoursesByDate(DateTime selectedDate)
        {
            return _courseRepository.GetCoursesByDate(selectedDate);
        }

        public  Course GetCourse(Guid courseId)
        {
            var course = _courseRepository.GetCourse(courseId);
            if (course == null) 
                throw new NotFoundCourseException(courseId);
            return course;
        }

        public async Task<Course> AddCourse(CourseAddDTO course)
        {
            if (course.ArivingTime <= DateTime.Now)
                throw new DateTimeNowExecption("Arriving Time");
            
            if (course.LeavingTime >= course.ArivingTime)
                throw new DateTimeNowExecption("Arriving Time","Leaving Time");

            return await _courseRepository.AddCourse(course);
        }
    }
}
