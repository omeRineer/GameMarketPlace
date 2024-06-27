using HangFire.Configuring;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFire.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        readonly IGeneralSchedulerService _generalSchedulerService;

        public JobsController(IGeneralSchedulerService generalSchedulerService)
        {
            _generalSchedulerService = generalSchedulerService;
        }

        [HttpGet("Sync")]
        public void Sync() => _generalSchedulerService.Sync();
    }
}
