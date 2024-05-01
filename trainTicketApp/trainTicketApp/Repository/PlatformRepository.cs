using trainTicketApp.Data;
using trainTicketApp.Model;

namespace trainTicketApp.Repository
{
    public class PlatformRepository
    {
        private readonly TraintDataApi.TrainDbContext _trainDbContext;

        public PlatformRepository(TraintDataApi.TrainDbContext trainDbContext)
        {
            _trainDbContext = trainDbContext;
        }

        public List<TrainPlatforms> GetAllPlatforms()
        {
            return _trainDbContext.TrainPlatforms.ToList();
        }

        public TrainPlatforms GetPlatformById(Guid id)
        {
            return _trainDbContext.TrainPlatforms.FirstOrDefault(x => x.PlatformID == id);
        }

        public string GetPlatformCity(Guid id)
        {
            return _trainDbContext.TrainPlatforms.FirstOrDefault(x => x.PlatformID == id).City;
        }

        public string GetPlatformName(Guid id)
        {
            return _trainDbContext.TrainPlatforms.FirstOrDefault(x => x.PlatformID == id).Name;
        }

        public List<String> GetPlatformsByCity(string name)
        {
            return _trainDbContext.TrainPlatforms.
                Where(p => p.City == name)
                .Select(p => p.Name).
                ToList();
        }
    }
}
