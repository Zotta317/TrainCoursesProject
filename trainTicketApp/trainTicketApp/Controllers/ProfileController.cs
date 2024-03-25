using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trainTicketApp.Model;
using trainTicketApp.ModelView;
using  trainTicketApp.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using trainTicketApp.Framework.Identity;

namespace trainTicketApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly TraintDataApi.TrainDbContext trainDbContext;

        public ProfileController(TraintDataApi.TrainDbContext dbContext)
        {
            trainDbContext = dbContext;
        }

        [HttpGet]

        [Authorize(Roles = AppRoles.Admin)]
        public async Task<Profile[]> ListProfiles()
        {
            return await trainDbContext.User.ToArrayAsync();
        }

        [HttpGet("Users")]
        public IActionResult GetProfile()
        {
            Identity identity = ControllerContext.GetIdentity();

            Profile userProfile = trainDbContext.User.FirstOrDefault(p => p.ID == identity.ID);

            var profile = new UserProfile
            {
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Role = userProfile.Role,
                NickName = userProfile.NickName,
                EmailAddress = userProfile.EmailAddress,
                IsAdmin = userProfile.IsAdmin,

            };
            

            return Ok(profile);
        }

        [HttpPut("EditProfile")]
        public async Task<IActionResult> PutProfile(UserProfile userProfile)
        {
            Identity identity = ControllerContext.GetIdentity();

            Guid profileID = identity.ID;

            Profile user = trainDbContext.User.FirstOrDefault(p => p.ID == profileID);

            user.Role = userProfile.Role;
            user.NickName = userProfile.NickName;
            user.FirstName = userProfile.FirstName;
            user.LastName = userProfile.LastName;


            try
            {
                await trainDbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(profileID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProfile(Guid id)
        {
            var profile = await trainDbContext.User.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            trainDbContext.User.Remove(profile);
            await trainDbContext.SaveChangesAsync();
            return NoContent();
        }


        private bool UserExists(Guid id)
        {
            return (trainDbContext.User?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
