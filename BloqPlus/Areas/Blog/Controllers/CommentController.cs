using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment com)
        {
            //Session
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            
            com.CommentStatus = true;
            com.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            com.WriterId = sessionUser.WriterId;
            com.BlogID = 2;

            cm.TAdd(com);
            return PartialView();
        }
    }
}
