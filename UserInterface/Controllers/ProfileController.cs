using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
