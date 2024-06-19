using Microsoft.AspNetCore.Mvc;

namespace UserInterface.ViewComponents
{
    public class FeaturesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
