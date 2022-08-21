using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class BrowseSettings:ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }
    }
}
