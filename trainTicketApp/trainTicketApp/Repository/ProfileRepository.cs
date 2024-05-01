using trainTicketApp.Data;
using trainTicketApp.DTOs;
using trainTicketApp.Model;

namespace trainTicketApp.Repository
{
    public interface IProfileRepository
    {
        public Profile GetProfileById(Guid userId);
        public ProfileGetDTO GetProfileDTOById(Guid userId);

        public List<Profile> GetAllProfiles();
    }
    public class ProfileRepository : IProfileRepository
    {
        private readonly TraintDataApi.TrainDbContext _trainDbContext;

        public ProfileRepository(TraintDataApi.TrainDbContext trainDbContext)
        {
            _trainDbContext = trainDbContext;
        }

        public Profile GetProfileById(Guid userId)
        {
            return _trainDbContext.User.FirstOrDefault(u => u.ID == userId);
        }

        public List<Profile> GetAllProfiles()
        {
            return _trainDbContext.User.Where(p => p.IsAdmin == false).ToList();
        }

        public ProfileGetDTO GetProfileDTOById(Guid userId)
        {
            var user = _trainDbContext.User.FirstOrDefault(p => p.ID == userId);

            var profile = new ProfileGetDTO { 
                    Name = $"{user.FirstName}{user.LastName}",
                    Role = user.Role,
                    NickName = user.NickName,
                    EmailAddress = user.EmailAddress,
                    IsAdmin = user.IsAdmin,
            };

            return profile;
        }
    }
}
