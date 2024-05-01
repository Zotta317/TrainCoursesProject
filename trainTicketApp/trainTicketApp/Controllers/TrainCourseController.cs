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
    public class TrainCourseController : Controller
    {

        private readonly ITrainCourseService _trainCourseService;

        public TrainCourseController(ITrainCourseService trainCourseService)
        {
            _trainCourseService = trainCourseService;
        }

        [HttpGet("{date}")]
        public List<CourseGetDTO> GetTrainCourseByDate(DateTime date, string? arrivingCity,string? leavingCity)
        {
            return _trainCourseService.GetAll(date,arrivingCity,leavingCity);
        }

        [HttpPost]
        public Task AddTrainCourse(CourseAddDTO courseAddDTO)
        {
            return _trainCourseService.AddTrainCourse(courseAddDTO);
        }

        [HttpGet("{courseId}")]
        public TrainCourse TrainCourse(Guid courseId)
        {
            return _trainCourseService.GetTrainCourseById(courseId);
        }
    }
}
