using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EntityLayer.Concreate;
using X.PagedList;

namespace BloqPlus.Areas.Blog.ViewComponents.Mail
{
    public class MailContent:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke(int id)
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            id = sessionUser.WriterId;

            var values = messageManager.GetMyInbox(id);
            return View(values);
        }
    }
}
