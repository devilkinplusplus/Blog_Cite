using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Mail
{
    public class OnlineFriends:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
