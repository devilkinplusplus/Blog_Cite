using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Blog
{
    public class AddComment:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
