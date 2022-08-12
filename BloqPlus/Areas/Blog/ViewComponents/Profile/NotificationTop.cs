using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Profile
{
    public class NotificationTop:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
