using Microsoft.AspNetCore.Mvc;

namespace UserInterface.ViewComponents
{
    public class MainBannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
