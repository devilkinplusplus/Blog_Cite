using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class MainWidgets:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            MainStats();
            return View();
        }

        private void MainStats()
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));

            var writers = c.Writers.Count();
            var blogs = c.Blogs.Where(x => x.BlogStatus == true).Count();
            var percentage = (writers * 100) / blogs;
            var comments = c.Comments.Count();
            var comPer = (comments * 100) / blogs;
            var dateLastBlog = c.Blogs.ToList().Where(x=>x.WriterId==sessionUser.WriterId).TakeLast(1).Select(x=>x.BlogCreateDate).FirstOrDefault();

            ViewBag.dLb = dateLastBlog.ToString("dd MMM"); 
            ViewBag.comm = comPer.ToString("#,##0");
            ViewBag.perc = percentage.ToString("#,##0");
            ViewBag.CoU = writers;
        }
    }
}
