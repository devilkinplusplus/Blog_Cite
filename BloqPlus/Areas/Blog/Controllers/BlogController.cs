using BusinessLayer.Concreate;
using X.PagedList;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
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
            return View(data);
        }

    }
}
