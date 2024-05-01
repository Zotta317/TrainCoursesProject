//using trainTicketApp.Migrations;
using trainTicketApp.DTOs;
using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public interface ITrainCourseRepository
    {
        public Task AddTrainCourse(CourseAddDTO courseAddDTO);
        public List<CourseGetDTO> GetAll(DateTime date);
        public TrainCourse GetTrainCourseById(Guid id);
    }
    public class TrainCourseRepository : ITrainCourseRepository
    {
        private readonly TrainDbContext _trainDbContext;
        private readonly PlatformRepository _trainPlatforms;
        private readonly TrainRepository _trainRepository;
        private readonly CourseRepository _courseRepository;
        private readonly CourseSeatsRepository _courseSeatsRepository;
        public TrainCourseRepository(TrainDbContext trainDbContext, PlatformRepository trainPlatforms,TrainRepository trainRepository,CourseSeatsRepository courseSeatsRepository,
            CourseRepository courseRepository)
        {
            _trainDbContext = trainDbContext;
            _trainPlatforms = trainPlatforms;
            _trainRepository = trainRepository;
            _courseSeatsRepository = courseSeatsRepository;
            _courseRepository = courseRepository;
        }

        public List<CourseGetDTO> GetAll(DateTime date)
        {
            var courses = _trainDbContext.TrainCourses.Where(tc => tc.LeavingDate >= date).ToList();

            var trainCoursesDTOs = new List<CourseGetDTO>();

            foreach (var course in courses)
            {
                var courseDTO = new CourseGetDTO
                {
                    CourseID = course.CourseId,
                    LeavingCity = _trainPlatforms.GetPlatformCity(course.Leavingcity),
                    ArrivingCity = _trainPlatforms.GetPlatformCity(course.ArrivingCity),
                    NumberOfSeatsAvailable = _courseSeatsRepository.GetAvailableSeats(course.CourseId),
                    LeavingTime = course.LeavingDate,
                    ArivingTime = course.ArrivingDate,
                    TrainName = _trainRepository.GetTrainName(course.TrainId),
                };

                trainCoursesDTOs.Add(courseDTO);
            }

            return trainCoursesDTOs;
        }

        //public List<CourseGetDTO> GetAllAvailableTrains(DateTime date)
        //{
        //    var courses = _trainDbContext.TrainCourses.Where(tc => tc.ArrivingDate >= date).ToList();

        //    var trainCoursesDTOs = new List<CourseGetDTO>();

        //    foreach (var course in courses)
        //    {
        //        var courseDTO = new CourseGetDTO
        //        {
        //            LeavingTime = course.LeavingDate
        //        }
        //    }

        //}

        public async Task AddTrainCourse(CourseAddDTO courseAddDTO)
        {
            var courseToAdd = new TrainCourse
            {
                CourseId =  Guid.NewGuid(),
                TrainId = courseAddDTO.TrainId,
                Leavingcity = courseAddDTO.LeavingCity,
                ArrivingCity = courseAddDTO.ArrivingCity,
                LeavingDate = courseAddDTO.LeavingTime,
                ArrivingDate = courseAddDTO.ArivingTime,
                AvaillableSeats = _trainRepository.GetTrainSeatsNumber(courseAddDTO.TrainId)
            };

            await _trainDbContext.TrainCourses.AddAsync(courseToAdd);

            await _courseRepository.AddCourse(courseToAdd);
            await _courseSeatsRepository.AddCourseSeats(courseToAdd);
            await _trainDbContext.SaveChangesAsync();
            //return courseAddDTO;
        }

        public TrainCourse GetTrainCourseById(Guid id)
        {
            return _trainDbContext.TrainCourses.FirstOrDefault(tc => tc.CourseId == id);
        }

        //public async Task AddTrainCourse(Course course)
        //{
        //    var trainCourse = new TrainCourse
        //    {
        //        CourseId = course.CourseID,
        //        TrainId = course.TrainId,
        //        AvailableDate = course.ArivingTime,
        //        ArrivingCity = _trainPlatforms.GetPlatformCity(course.ArrivingCity),
        //    };

        //    await _trainDbContext.TrainCourses.AddAsync(trainCourse);
        //    _trainDbContext.SaveChanges();
        //}
        //public List<TrainCourseGetDTO> GetTrainCoursesByCity(string city)
        //{
        //    var trainCourses = _trainDbContext.TrainCourses.Where(tc => tc.ArrivingCity == city).ToList();

        //    var trainCoursesDTOs = new List<TrainCourseGetDTO>();
        //    foreach (var trainCourse in trainCourses)
        //    {
        //        var trainCourseDTO = new TrainCourseGetDTO
        //        {
        //            CourseId = trainCourse.CourseId,
        //            TrainName = _trainRepository.GetTrainName(trainCourse.TrainId),
        //            AvailableDate = trainCourse.AvailableDate,
        //            ArrivingCity = trainCourse.ArrivingCity,
        //        };

        //        trainCoursesDTOs.Add(trainCourseDTO);
        //    }
        
        //    return trainCoursesDTOs;
        //}

        //public List<TrainCourseGetDTO> GetTrainCourses()
        //{
        //    var trainCourses = _trainDbContext.TrainCourses.ToList();

        //    var trainCoursesDTOs = new List<TrainCourseGetDTO>();
        //    foreach (var trainCourse in trainCourses)
        //    {
        //        var course = _courseRepository.GetCourseById(trainCourse.CourseId);
        //        var trainCourseDTO = new TrainCourseGetDTO
        //        {
        //            CourseId = trainCourse.CourseId,
        //            TrainName = _trainRepository.GetTrainName(trainCourse.TrainId),
        //            AvailableDate = trainCourse.AvailableDate,
        //            ArrivingCity = trainCourse.ArrivingCity,
        //            ArrivingPlatform = _trainPlatforms.GetPlatformName(course.ArrivingCity),
        //            LeavingCity = _trainPlatforms.GetPlatformCity(course.LeavingCity),
        //            LeavingPlatform = _trainPlatforms.GetPlatformName(course.LeavingCity)
        //        };

        //        trainCoursesDTOs.Add(trainCourseDTO);
        //    }

        //    return trainCourses;
        //}


        //public List<TrainCourse> GetTrainCoursesByDate(DateTime availableDate, string city)
        //{
        //    return _trainDbContext.TrainCourses.Where(tc => tc.AvailableDate < availableDate && tc.ArrivingCity == city).ToList();
        //}

    }
}
