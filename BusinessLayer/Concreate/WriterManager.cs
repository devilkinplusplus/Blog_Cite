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
    public class WriterManager : GenericManager<Writer>, IWriterService
    {
        public WriterManager(IGenericDal<Writer> genericDal) : base(genericDal)
        {
        }
    }
}
