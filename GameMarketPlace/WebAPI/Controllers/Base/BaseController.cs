using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Base
{
    [Route("webapi/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
