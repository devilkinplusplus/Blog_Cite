using BusinessLayer.Concreate;
using X.PagedList;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concreate;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = bm.TGetList();
            return View(values);
        }

        public IActionResult AllBlogs(int page=1)
        {

            var values = bm.GetBlogsWithCategory();
            return View(values.ToPagedList(page,9));
        }

        public IActionResult BlogReadAll(int id)
        {
            var one = bm.TGetById(id);
            var data = bm.GetBlogByIdWithCategory(id);
            //For other operations
            ViewBag.on = one.WriterId;
            ViewBag.bl = one.BlogID;

            //Comments Count for each blog
            var count = c.Comments.Where(x => x.BlogID == id).Count();
            ViewBag.cc = count;
            return View(data);
        }

    }
}
