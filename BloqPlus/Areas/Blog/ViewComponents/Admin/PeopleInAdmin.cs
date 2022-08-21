using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EntityLayer.Concreate;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class PeopleInAdmin : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            ViewBag.img = sessionUser.WriterImage;
            ViewBag.about = sessionUser.WriterAbout;

            var values = writerManager.TGetList().Where(x => x.WriterId != sessionUser.WriterId);

            return View(values);
        }


    }
}
