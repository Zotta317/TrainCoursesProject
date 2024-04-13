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

        Task<Course> AddCourse(CourseAddDTO course);
    }
    public class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<CourseGetDTO> GetCourses()
        {
            return _courseRepository.GetCourses();
        }

        public  Course GetCourse(Guid courseId)
        {
            return  _courseRepository.GetCourse(courseId);
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
