using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public class CarrigeRepository
    {
        private readonly TrainDbContext trainDbContext;

        public CarrigeRepository(TrainDbContext _trainDbContext)
        {
            trainDbContext = _trainDbContext;
        }

        public List<Carrige> GetAllCarrigies()
        {
            return trainDbContext.Carrige.ToList();
        }
        public Carrige GetCarrigeByTrain(Guid trainId)
        {
            return trainDbContext.Carrige.FirstOrDefault(c => c.TrainId == trainId);
        }
    }
}
