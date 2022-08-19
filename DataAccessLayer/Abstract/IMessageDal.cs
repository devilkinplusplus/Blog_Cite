using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        List<Message> GetMyInbox(int id);
        List<Message> GetMySent(int id);
        List<Message> GetMessageDetails(int id);
    }
}
