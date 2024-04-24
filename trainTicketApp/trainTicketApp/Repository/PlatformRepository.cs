using trainTicketApp.Data;
using trainTicketApp.Model;

namespace trainTicketApp.Repository
{
    public class PlatformRepository
    {
        private readonly TraintDataApi.TrainDbContext trainDbContext;

        public PlatformRepository(TraintDataApi.TrainDbContext _trainDbContext)
        {
            trainDbContext = _trainDbContext;
        }

        public List<TrainPlatforms> GetAllPlatforms()
        {
            return trainDbContext.TrainPlatforms.ToList();
        }

        public TrainPlatforms GetPlatformById(Guid id)
        {
            return trainDbContext.TrainPlatforms.FirstOrDefault(x => x.PlatformID == id);
        }

        public string GetPlatformCity(Guid id)
        {
            return trainDbContext.TrainPlatforms.FirstOrDefault(x => x.PlatformID == id).City;
        }

        public List<TrainPlatforms> GetPlatformsByCity(string name)
        {
            return trainDbContext.TrainPlatforms.Where(p => p.City == name).ToList();
        }
    }
}
