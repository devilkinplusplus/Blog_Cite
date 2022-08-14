using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Blog
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
