using trainTicketApp.DTOs;
using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public class CourseRepository 
    {
        private readonly TrainDbContext _trainDbContext;
        private readonly PlatformRepository _platformRepository;

        public CourseRepository(TrainDbContext trainDbContext, PlatformRepository platformRepository)
        {
            _trainDbContext = trainDbContext;
            _platformRepository = platformRepository;
        }

        public async Task AddCourse(TrainCourse trainCourse)
        {
            var course = new Course
            {
                CourseID = trainCourse.CourseId,
                ArrivingCity = _platformRepository.GetPlatformCity(trainCourse.ArrivingCity),
                LeavingCity = _platformRepository.GetPlatformCity(trainCourse.Leavingcity),
                LeavingTime = trainCourse.LeavingDate,
                ArivingTime = trainCourse.ArrivingDate,

            };

            await _trainDbContext.AddAsync(course);
            await _trainDbContext.SaveChangesAsync();
        }
     
            public Course GetCourseById(Guid id)
            {
                return _trainDbContext.Course.FirstOrDefault(c => c.CourseID == id);
            }
    }
}
