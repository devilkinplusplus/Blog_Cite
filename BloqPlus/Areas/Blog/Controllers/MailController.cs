using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class MailController : Controller
    {
        public IActionResult Inbox()
        {
            return View();
        }



    }
}
