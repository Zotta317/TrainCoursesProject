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

        private readonly ITrainPlatformService _trainPlatformService;

        public PlatformController(ITrainPlatformService trainPlatformService)
        {
            _trainPlatformService = trainPlatformService;
        }
        [HttpGet("{city}")]
        public List<String> GetPlatformsByCity(string city) 
        {
            return _trainPlatformService.GetPlatformsByCity(city);
        }

    }
}
