using Microsoft.AspNetCore.Mvc;

namespace GameStore.UserInterface.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
