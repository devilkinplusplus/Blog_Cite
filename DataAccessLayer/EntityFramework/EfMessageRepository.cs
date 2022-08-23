using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageRepository : GenericRepository<Message>, IMessageDal
    {
        Context con = new Context();

        public List<Message> GetMessageDetails(int id)
        {
            return con.Messages.Where(x => x.MessageID == id).Include(x=>x.SenderUser).ToList();
        }

        public List<Message> GetMyInbox(int id)
        {
            return con.Messages.Where(x => x.ReceiverID == id).OrderByDescending(x=>x.MessageDate).Include(x => x.SenderUser).ToList();
        }

        public List<Message> GetMySent(int id)
        {
            return con.Messages.Where(x => x.SenderID == id).Include(x => x.ReceiverUser).ToList();
        }
    }
}
