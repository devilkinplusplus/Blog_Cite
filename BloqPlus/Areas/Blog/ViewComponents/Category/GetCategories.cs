using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BloqPlus.Areas.Blog.ViewComponents.Category
{
    public class GetCategories : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            //var result = c.Blogs
            //    .GroupBy(x => x.CategoryID)
            //    .OrderByDescending(g => g.Count())
            //    .Take(3)
            //    .Select(x => new
            //    {
            //        CategoryName = x.First().Category.CategoryName,
            //        Count = x.Count()
            //    }).ToList();

            return View();
        }


    }
}
