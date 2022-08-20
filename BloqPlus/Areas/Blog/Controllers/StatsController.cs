using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EntityLayer.Concreate;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class StatsController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            //Session
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));


            // Count of Blogs
            ViewBag.CoB = c.Blogs.Where(x => x.WriterId == sessionUser.WriterId).Count();
            // Count of Active Blogs
            ViewBag.CoAB = c.Blogs.Where(x => x.WriterId == sessionUser.WriterId &&
            x.BlogStatus == true).Count();
            // Comments you write
            ViewBag.CoC = c.Comments.Where(x => x.WriterId == sessionUser.WriterId).Count();
            // Comments written you
            ViewBag.CoCbY = c.Comments.Where(x => x.BlogID == x.BlogID
            && x.Blog.WriterId == sessionUser.WriterId).Count();

            // Messages you send 
            ViewBag.MyS = c.Messages.Where(x => x.SenderID == sessionUser.WriterId).Count();
            // Messages sent you
            ViewBag.MbS = c.Messages.Where(x => x.ReceiverID == sessionUser.WriterId).Count();

            // Your Writer Id
            ViewBag.YwI = sessionUser.WriterId;
            

            // Random blog
            Random rand = new Random();
            int toSkip = rand.Next(1, c.Blogs.Count());
            var randomObject = c.Blogs.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).FirstOrDefault();
            ViewBag.rand = randomObject.BlogID;

            ViewBag.pp = sessionUser.WriterImage;
            ViewBag.name = sessionUser.WriterName;
            ViewBag.about = sessionUser.WriterAbout;
            



            return View();
        }
    }
}
