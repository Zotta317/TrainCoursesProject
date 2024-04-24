using trainTicketApp.DTOs;
using trainTicketApp.Model;
using trainTicketApp.Repository;
using trainTicketApp.Validation;

namespace trainTicketApp.Service
{
    public interface ICourseService
    {
        List<CourseGetDTO> GetAllCourses();
        Course GetCourse(Guid courseId);

        List<CourseGetDTO> GetCoursesByDate(DateTime date,string? arrivingCity,string? leavingCity);

        Task<Course> AddCourse(CourseAddDTO course);
    }
    public class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<CourseGetDTO> GetAllCourses()
        {
            return _courseRepository.GetAllCourses();
        }

        public List<CourseGetDTO> GetCoursesByDate(DateTime selectedDate,string? arrivingCity, string? leavingCity)
        {
            var courses = _courseRepository.GetCoursesByDate(selectedDate);

            if (leavingCity != null)
                courses = courses.Where(course => course.LeavingCity == leavingCity).ToList();
            if (arrivingCity != null)
                courses = courses.Where(course => course.ArrivingCity == arrivingCity).ToList();

            return courses;
        }

        public  Course GetCourse(Guid courseId)
        {
            var course = _courseRepository.GetCourseById(courseId);
            return course == null ? throw new NotFoundCourseException(courseId) : course;
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
