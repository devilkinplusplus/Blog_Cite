using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class AdminInfo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
