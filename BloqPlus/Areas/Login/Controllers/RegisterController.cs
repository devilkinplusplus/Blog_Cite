using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Login.Controllers
{
    [Area("Login")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(WriterWithPP user)
        {
            Writer w = new Writer();
            WriterValidator validations = new WriterValidator();
            ValidationResult result = validations.Validate(user);


            if (user.WriterImage != null)
            {
                var extension = Path.GetExtension(user.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), 
                    "wwwroot/ProfilPictures", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                user.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterName = user.WriterName;
            w.WriterMail= user.WriterMail;
            w.WriterAbout= user.WriterAbout;
            w.WriterPassword= user.WriterPassword;
            w.WriterConfirmPassword= user.WriterConfirmPassword;
            w.WriterStatus = user.WriterStatus = true;

            if (result.IsValid)
            {
                if (user.WriterConfirmPassword==user.WriterPassword)
                {
                    wm.TAdd(w);
                    return RedirectToAction("Index", "Login");
                }
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
    }
}
