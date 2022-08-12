using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Profile
{
    public class MailTop:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
