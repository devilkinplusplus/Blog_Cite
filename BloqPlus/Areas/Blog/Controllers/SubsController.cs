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
    public class SubsController : Controller
    {
        NewsManager news = new NewsManager(new EfNewsRepository());
        [HttpGet]
        public PartialViewResult Subscribe()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Subscribe(News param)
        {
            NewsValidator validations = new NewsValidator();
            ValidationResult result = validations.Validate(param);

            if (result.IsValid)
            {
                param.NewsStatus = true;
                news.TAdd(param);
            }
            return PartialView();
        }
    }
}
