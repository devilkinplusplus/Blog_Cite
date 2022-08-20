using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class MessagesNoti:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        Context c = new Context();
        public IViewComponentResult Invoke(int id)
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            id = sessionUser.WriterId;
            // Messages sent you
            ViewBag.MbS = c.Messages.Where(x => x.ReceiverID == sessionUser.WriterId).Count();

            var values = messageManager.GetMyInbox(id);
            return View(values);
        }
    }
}
