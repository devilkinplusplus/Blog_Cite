﻿using BusinessLayer.Concreate;
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

        public IActionResult AllBlogs()
        {
            var values = bm.GetBlogsWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            var one = bm.TGetById(id);
            var data = bm.GetBlogByIdWithCategory(id);
            ViewBag.on = one.WriterId;
            return View(data);
        }

    }
}
