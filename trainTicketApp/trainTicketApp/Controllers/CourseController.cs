using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trainTicketApp.Data;
using trainTicketApp.Model;
using trainTicketApp.ModelView;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly TraintDataApi.TrainDbContext trainDbContext;

        public CourseController(TraintDataApi.TrainDbContext dbContext)
        {
            trainDbContext = dbContext;
        }

        //[HttpGet("GetAllCourses")]
        //public IActionResult GetAllCourses(String selectedLeavingTime)
        //{

        //    var selectedDate = DateTime.Parse(selectedLeavingTime);
        //    var query = trainDbContext.Course.Where(c => c.LeavingTime >= selectedDate);
            
        //    var courses = query.Select(c => new CourseView
        //    {
        //        CourseID = c.CourseID,
        //        LeavingCity = c.LeavingCity,
        //        ArrivingCity = c.ArrivingCity,
        //        LeavingTime = c.LeavingTime,
        //        ArrivingTime = c.ArivingTime,
        //        AvailableTrainSeats = trainDbContext.Seat
        //                             .Count(s => s.Booked == false && s.CourseId == c.CourseID),
        //        TrainName = trainDbContext.Train.FirstOrDefault(t => t.TrainID == c.TrainId).TrainName,
        //    }).ToList();


        //    //var courses = (from course in trainDbContext.Course
        //    //   join train in trainDbContext.Train on course.TrainId equals train.TrainID
        //    //   select new CourseView
        //    //   {
        //    //       CourseID = course.CourseID,
        //    //       LeavingCity = course.LeavingCity,
        //    //       ArrivingCity = course.ArrivingCity,
        //    //       LeavingTime = course.LeavingTime,
        //    //       ArrivingTime = course.ArivingTime,
        //    //       AvailableTrainSeats = trainDbContext.Seat
        //    //                      .Count(s => s.Booked == false && s.CourseId == course.CourseID),
        //    //       TrainName = train.TrainName,
        //    //   }).ToList();

        //    return Ok(courses);
        //}



        //[HttpPost("AddCourses")]
        //public async Task<IActionResult> AddCourse(CourseInput courseInput)
        //{
        //    var train = await trainDbContext.Train.FirstOrDefaultAsync(s => s.TrainName == courseInput.TrainName);

        //    if (train != null)
        //    {
        //        //Service sa adaug validari 
        //        var course = new Course
        //        {
        //            CourseID = Guid.NewGuid(),
        //            LeavingCity = courseInput.LeavingCity,
        //            ArrivingCity = courseInput.ArrivingCity,
        //            LeavingTime = courseInput.LeavingTime,
        //            ArivingTime = courseInput.ArivingTime,
        //            TrainId = train.TrainID,
        //            PlatformId = courseInput.PlatformId,
        //            NumberOfSeatsAvailable = train.NumberOfSeats
        //        };



        //        trainDbContext.Course.Add(course);

        //        await trainDbContext.SaveChangesAsync();

        //        await AddSeatsForCourse(course.CourseID, train.TrainID);

        //        return NoContent();

        //    }
        //    else
        //    {
        //        return NotFound("Train not found.");
        //    }
        //}

        //private async Task AddSeatsForCourse(Guid courseId, Guid trainId)
        //{
        //    var carriages = await trainDbContext.Carrige.Where(c => c.TrainId == trainId).ToListAsync();
            
        //    foreach (var carriage in carriages)
        //    {
               
        //        for (int seatNumber = 1; seatNumber <= carriage.AvailableSeats; seatNumber++)
        //        {
        //            var seat = new Seat
        //            {
        //                SeatID = Guid.NewGuid(),
        //                SeatName = $"Seat {seatNumber}",
        //                CarrigeId = carriage.CarrigeID,
        //                Booked = false,
        //                TrainId = trainId,
        //                CourseId = courseId
        //            };

        //            trainDbContext.Seat.Add(seat);
        //        }

                
        //    }

        //    await trainDbContext.SaveChangesAsync();
        //}

    }

   
}
