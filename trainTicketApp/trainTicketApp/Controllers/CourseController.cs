using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trainTicketApp.DTOs;
using trainTicketApp.Model;
using trainTicketApp.Service;

namespace trainTicketApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<List<CourseGetDTO>> GetCourses()
        {
            var courses = _courseService.GetCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(Guid id)
        {
            var course = _courseService.GetCourse(id);
            return Ok(course);
        }

        [HttpPost("AddCourses")]
        public async Task<IActionResult> AddCourse(CourseAddDTO course)
        {
            var newCourse = await _courseService.AddCourse(course);
            return CreatedAtAction(nameof(AddCourse), course);
         }

    }

   
}
