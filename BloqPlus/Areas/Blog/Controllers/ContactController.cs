using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager contact = new ContactManager(new EfContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact msg)
        {
            ContactValidator validations = new ContactValidator();
            ValidationResult result = validations.Validate(msg);

            msg.ContactStatus = true;

            if (!result.IsValid)
            {
                return RedirectToAction("Index");
            }

            contact.TAdd(msg);
            return RedirectToAction("AllBlogs","Blog");
        }
    }
}
