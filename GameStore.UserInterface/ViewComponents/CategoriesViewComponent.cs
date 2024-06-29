using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UserInterface.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
