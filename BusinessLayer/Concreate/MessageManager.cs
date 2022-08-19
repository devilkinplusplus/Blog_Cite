using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class MessageManager : GenericManager<Message>, IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IGenericDal<Message> genericDal) : base(genericDal)
        {
            this._messageDal = (IMessageDal)genericDal;
        }

        public List<Message> GetMessageDetails(int id)
        {
            return _messageDal.GetMessageDetails(id);
        }

        public List<Message> GetMyInbox(int id)
        {
            return _messageDal.GetMyInbox(id);
        }

        public List<Message> GetMySent(int id)
        {
            return _messageDal.GetMySent(id);
        }
    }
}
