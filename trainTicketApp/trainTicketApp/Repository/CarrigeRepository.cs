using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public class CarrigeRepository
    {
        private readonly TrainDbContext _trainDbContext;

        public CarrigeRepository(TrainDbContext trainDbContext)
        {
           _trainDbContext = trainDbContext;
        }

        public List<Carrige> GetAllCarrigies()
        {
            return _trainDbContext.Carrige.ToList();
        }
        public Carrige GetCarrigeByTrain(Guid trainId)
        {
            return _trainDbContext.Carrige.FirstOrDefault(c => c.TrainId == trainId);
        }
    }
}
