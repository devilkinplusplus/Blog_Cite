using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Mail
{
    public class MailContent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
