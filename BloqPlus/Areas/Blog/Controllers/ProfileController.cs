using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class ProfileController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult UpdateProfile(int id)
        {
            var data = wm.TGetById(id);
            ViewData["img"] = data.WriterImage;
            return View(data);
        }


        [HttpPost]
        public IActionResult UpdateProfile(WriterWithPP user, int id)
        {
            var data = wm.TGetById(id);
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
                data.WriterImage = newimagename;
            }
            data.WriterName = user.WriterName;
            data.WriterMail = user.WriterMail;
            data.WriterAbout = user.WriterAbout;
            data.WriterPassword = user.WriterPassword;
            data.WriterConfirmPassword = user.WriterConfirmPassword;
            data.WriterStatus = user.WriterStatus = true;

            if (!result.IsValid)
            {
                return RedirectToAction("UpdateProfile");
            }
            if (user.WriterPassword == user.WriterConfirmPassword)
            {
                wm.TUpdate(data);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("UpdateProfile");

        }
    }
}
