using trainTicketApp.Data;
using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public class TrainRepository
    {
        private readonly TrainDbContext _trainDbContext;

        public TrainRepository(TrainDbContext context)
        {
            _trainDbContext = context;
        }

        public List<Train> GetAllTrains()
        {
            return _trainDbContext.Train.ToList();
        }

        public Train GetTrainById(Guid trainId)
        {
            return _trainDbContext.Train.FirstOrDefault(train => train.TrainID == trainId);
        }

        public string GetTrainName(Guid trainId)
        {
            return _trainDbContext.Train.FirstOrDefault(train => train.TrainID == trainId).TrainName;
        }

        public int GetTrainSeatsNumber(Guid trainId)
        {
            return _trainDbContext.Train.FirstOrDefault(train => train.TrainID == trainId).NumberOfSeats;
        }
    }
}
