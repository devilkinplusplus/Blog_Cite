using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class PeopleInAdmin:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
