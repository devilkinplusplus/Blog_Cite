using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class ProfileController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            DropdownCategoryValues();
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(BlogWithImg newBlog)
        {
            EntityLayer.Concreate.Blog b = new EntityLayer.Concreate.Blog();

            //session id
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));

            BlogValidator validations = new BlogValidator();
            ValidationResult result = validations.Validate(newBlog);

            if (newBlog.BlogImage != null)
            {
                var extension = Path.GetExtension(newBlog.BlogImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/BlogImage", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                newBlog.BlogImage.CopyTo(stream);
                b.BlogImage = newimagename;
            }
            b.BlogTitle = newBlog.BlogTitle;
            b.BlogContent = newBlog.BlogContent;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.BlogStatus = true;
            b.WriterId = sessionUser.WriterId;
            b.CategoryID = newBlog.CategoryID;
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("AddBlog");
            }
 
            bm.TAdd(b);
            return RedirectToAction("Index");
        }

        public IActionResult BlogList(int id)
        {
            var sessionUser = JsonConvert.DeserializeObject<EntityLayer.Concreate.Blog>(HttpContext.Session.GetString("username"));
            id = sessionUser.WriterId;
            var values = bm.GetBlogsWithCategoryByWriter(id);
            return View(values);
        }

        private void DropdownCategoryValues()
        {
            Context con = new Context();
            List<SelectListItem> values = (from x in con.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            DropdownCategoryValues();
            var data = bm.TGetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateBlog(BlogWithImg blog)
        {
            return RedirectToAction("Index");
        }
    }
}
