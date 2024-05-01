using trainTicketApp.DTOs;
using trainTicketApp.Model;
using trainTicketApp.Repository;

namespace trainTicketApp.Service
{
    public interface ITrainCourseService
    {
        public Task AddTrainCourse(CourseAddDTO courseAddDTO);
        public List<CourseGetDTO> GetAll(DateTime date,string arrivingCity,string leavingCity);
        public TrainCourse GetTrainCourseById(Guid id);

    }
    public class TrainCourseService : ITrainCourseService
    {
        private readonly ITrainCourseRepository _trainCourseRepository;

        public TrainCourseService(ITrainCourseRepository trainCourseRepository)
        {
            _trainCourseRepository = trainCourseRepository;
        }

        //    public List<TrainCourseGetDTO> GetTrainCoursesByCity(string city)
        //    {
        //        return _trainCourseRepository.GetTrainCoursesByCity(city);
        //    }
        public Task AddTrainCourse(CourseAddDTO courseAddDTO)
        {
            return _trainCourseRepository.AddTrainCourse(courseAddDTO);
        }

        public List<CourseGetDTO> GetAll(DateTime date, string arrivingCity, string leavingCity)
        {
            var trainCourses = _trainCourseRepository.GetAll(date);
            
            if(arrivingCity != null)
                trainCourses = trainCourses.Where(tc => tc.ArrivingCity == arrivingCity).ToList(); 

            if(leavingCity != null)
                trainCourses = trainCourses.Where(tc => tc.LeavingCity == leavingCity).ToList();
        
            return trainCourses;
        }

        public TrainCourse GetTrainCourseById(Guid id)
        {
            return _trainCourseRepository.GetTrainCourseById(id);
        }
    }
}
