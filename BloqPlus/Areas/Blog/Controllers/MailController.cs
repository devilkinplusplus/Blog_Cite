using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BloqPlus.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class MailController : Controller
    {

        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        Context c = new Context();
        public IActionResult Inbox()
        {
            UpdateProfileId();
            return View();
        }

        [HttpGet]
        public IActionResult Compose()
        {
            UpdateProfileId();
            WriterMails();
            return View();
        }

        [HttpPost]
        public IActionResult Compose(Message msg)
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));

            MessageValidator validations = new MessageValidator();
            ValidationResult result = validations.Validate(msg);

            msg.SenderID = sessionUser.WriterId;
            msg.MessageStatus = true;
            msg.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            if (!result.IsValid)
            {
                return RedirectToAction("Compose");
            }
            messageManager.TAdd(msg);
            return RedirectToAction("Sent");
        }

        [NonAction]
        private void WriterMails()
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));

            List<SelectListItem> values = (from x in c.Writers.ToList()
                                           where x.WriterId != sessionUser.WriterId
                                           select new SelectListItem
                                           {
                                               Text = x.WriterMail,
                                               Value = x.WriterId.ToString()
                                           }).ToList();
            ViewBag.val = values;
        }

        public IActionResult MailReadAll(int id)
        {
            UpdateProfileId();
            var value = messageManager.GetMessageDetails(id);
            return View(value);
        }

        public IActionResult Sent(int id)
        {
            UpdateProfileId();
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));

            id = sessionUser.WriterId;
            var values = messageManager.GetMySent(id);
            return View(values);
        }

        [NonAction]
        private void UpdateProfileId()
        {
            //Update
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            ViewBag.id = sessionUser.WriterId;
        }

    }
}
