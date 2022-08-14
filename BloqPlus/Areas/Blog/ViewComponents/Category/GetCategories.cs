using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BloqPlus.Areas.Blog.ViewComponents.Category
{
    public class GetCategories:ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var values = cm.GetMostRepeateds();
            return View(values.Take(3));
        }

        private void Stats()
        {


        }
    }
}
