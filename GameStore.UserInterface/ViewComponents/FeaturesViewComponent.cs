using Microsoft.AspNetCore.Mvc;

namespace GameStore.UserInterface.ViewComponents
{
    public class FeaturesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
