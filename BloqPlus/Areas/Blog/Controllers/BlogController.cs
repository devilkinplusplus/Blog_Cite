using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    [AllowAnonymous]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
