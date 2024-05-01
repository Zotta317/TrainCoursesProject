using trainTicketApp.Repository;

namespace trainTicketApp.Service
{
    public class ProfileService
    {
        private readonly ProfileRepository profileRepository;

        public ProfileService(ProfileRepository _profileRepository)
        {
            profileRepository = _profileRepository;
        }



    }
}
