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
    
    public class AdminController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            UpdateProfileId();
            return View();
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            UpdateProfileId();
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
                TempData["NotEmpty"] = "Xanalari doldurun";
                return RedirectToAction("AddBlog");
            }

            bm.TAdd(b);
            return RedirectToAction("Index");

        }

        [NonAction]
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
        [NonAction]
        private void UpdateProfileId()
        {
            //Update
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            ViewBag.id = sessionUser.WriterId;
        }

        public IActionResult BlogList(int id)
        {
            UpdateProfileId();
            var sessionUser = JsonConvert.DeserializeObject<EntityLayer.Concreate.Blog>(HttpContext.Session.GetString("username"));
            id = sessionUser.WriterId;
            var values = bm.GetBlogsWithCategoryByWriter(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            UpdateProfileId();
            DropdownCategoryValues();
            var data = bm.TGetById(id);
            data.BlogStatus = true;
            ViewData["img"] = data.BlogImage;
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateBlog(BlogWithImg blog, int id)
        {
            var data = bm.TGetById(id);


            BlogValidator validations = new BlogValidator();
            ValidationResult result = validations.Validate(blog);
            if (blog.BlogImage != null)
            {
                var extension = Path.GetExtension(blog.BlogImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/BlogImage", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                blog.BlogImage.CopyTo(stream);
                data.BlogImage = newimagename;
            }

            data.BlogTitle = blog.BlogTitle;
            data.BlogContent = blog.BlogContent;
            data.BlogStatus = true;
            data.CategoryID = blog.CategoryID;
            if (!result.IsValid)
            {
                TempData["NotEmpty"] = "Xanalari doldurun";
                return RedirectToAction("UpdateBlog");
            }

            bm.TUpdate(data);
            return RedirectToAction("BlogList");
        }

        public IActionResult DeleteBlog(int id)
        {
            var data = bm.TGetById(id);
            bm.TDelete(data);
            return RedirectToAction("Index");
        }

        public IActionResult CheckStatus(int id)
        {
            var data = bm.TGetById(id);
            if (data.BlogStatus)
            {
                data.BlogStatus = false;
            }
            else
            {
                data.BlogStatus = true;
            }
            bm.TUpdate(data);
            return RedirectToAction("BlogList");
        }


    }
}
