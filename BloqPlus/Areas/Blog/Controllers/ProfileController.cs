using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    [AllowAnonymous]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
