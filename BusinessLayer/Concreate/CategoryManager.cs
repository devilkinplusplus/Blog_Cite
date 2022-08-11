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
    public class CategoryManager : GenericManager<Category> , ICategoryService
    {
        public CategoryManager(IGenericDal<Category> genericDal):base(genericDal)
        {
        }
    }
}
