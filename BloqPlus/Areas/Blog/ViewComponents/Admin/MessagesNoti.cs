using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class MessagesNoti:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
