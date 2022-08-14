using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BloqPlus.Areas.Blog.ViewComponents.Blog
{
    public class OtherBlogsOfWriter:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke(int id)
        {
            var rslt = bm.GetOtherBlogsByWriter(id).TakeLast(2);
            return View(rslt);
        }
    }
}
