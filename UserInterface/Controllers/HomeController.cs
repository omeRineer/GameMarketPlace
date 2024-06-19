using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
