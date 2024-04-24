using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trainTicketApp.Model;
using trainTicketApp.Service;

namespace trainTicketApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlatformController : Controller
    {

        private readonly ITrainPlatformService trainPlatformService;

        public PlatformController(ITrainPlatformService _trainPlatformService)
        {
            trainPlatformService = _trainPlatformService;
        }
        [HttpGet("{city}")]
        public List<TrainPlatforms> GetPlatformsByCity(string city) 
        {
            return trainPlatformService.GetPlatformsByCity(city);
        }

    }
}
