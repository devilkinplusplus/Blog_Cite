using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Login.Controllers
{   
    [Area("Login")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
