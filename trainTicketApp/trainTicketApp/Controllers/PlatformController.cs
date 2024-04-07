using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using trainTicketApp.Data;
using trainTicketApp.Model;
using trainTicketApp.ModelView;

namespace trainTicketApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlatformController : Controller
    {
        private readonly TraintDataApi.TrainDbContext trainDbContext;

        public PlatformController(TraintDataApi.TrainDbContext dbContext)
        {
            trainDbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetPlatform(string leavingCity)
        {
           var platforms = trainDbContext.TrainPlatforms.Where(p => p.City == leavingCity).Select(p =>
                new PlatformView
                {
                    PlatformID = p.PlatformID,
                    City = p.City,
                    Name = p.Name,
                }
                ).ToList();

            return Ok(platforms);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlatform(PlatformView platfomrView)
        {
            var platform = new TrainPlatforms
            {
                PlatformID = platfomrView.PlatformID,
                City = platfomrView.City,
                Name = platfomrView.Name,
            };

            try
            {
                trainDbContext.TrainPlatforms.Add(platform);
                await trainDbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformExists(platform.PlatformID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool PlatformExists(Guid id)
        {
            return (trainDbContext.TrainPlatforms?.Any(e => e.PlatformID == id)).GetValueOrDefault();
        }
    }
}
