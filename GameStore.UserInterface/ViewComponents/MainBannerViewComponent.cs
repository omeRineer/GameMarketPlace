using Microsoft.AspNetCore.Mvc;

namespace GameStore.UserInterface.ViewComponents
{
    public class MainBannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
