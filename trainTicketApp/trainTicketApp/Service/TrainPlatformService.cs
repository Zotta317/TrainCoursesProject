using trainTicketApp.Model;
using trainTicketApp.Repository;

namespace trainTicketApp.Service
{
    public interface ITrainPlatformService
    {
        List<String> GetPlatformsByCity(string city);
    }
    public class TrainPlatformService : ITrainPlatformService
    {
        private readonly PlatformRepository _platformRepository;

        public TrainPlatformService(PlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public List<String> GetPlatformsByCity(string city)
        {
                return _platformRepository.GetPlatformsByCity(city);
        }
    }
}
