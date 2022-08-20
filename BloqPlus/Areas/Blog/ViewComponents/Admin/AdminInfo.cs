using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class AdminInfo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            ViewBag.pp = sessionUser.WriterImage;
            ViewBag.id = sessionUser.WriterId;
            return View();
        }
    }
}
