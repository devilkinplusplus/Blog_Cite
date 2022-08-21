using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class GetWeather:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
