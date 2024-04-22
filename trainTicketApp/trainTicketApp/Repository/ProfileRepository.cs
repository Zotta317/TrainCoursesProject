using trainTicketApp.Data;
using trainTicketApp.Model;

namespace trainTicketApp.Repository
{
    public class ProfileRepository
    {
        private readonly TraintDataApi.TrainDbContext trainDbContext;

        public ProfileRepository(TraintDataApi.TrainDbContext _trainDbContext)
        {
            trainDbContext = _trainDbContext;
        }

        public Profile GetProfileById(Guid userId)
        {
            return trainDbContext.User.FirstOrDefault(u => u.ID == userId);
        }
    }
}
