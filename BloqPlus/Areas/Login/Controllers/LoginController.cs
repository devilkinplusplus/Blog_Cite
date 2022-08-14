using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BloqPlus.Areas.Login.Controllers
{
    [Area("Login")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer user)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == user.WriterMail && x.WriterPassword == user.WriterPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,user.WriterMail)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("username", JsonConvert.SerializeObject(datavalue));
                return RedirectToAction("Index", "Blog",new { area="Blog" });
            }
            else
                return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Blog", new {area="Blog"});
        }
    }
}
