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
            var result = c.Categories.ToList().Take(3);

            return View(result);
        }


    }
}
