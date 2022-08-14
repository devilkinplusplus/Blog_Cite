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
        ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal):base(genericDal)
        {
            this._categoryDal = (ICategoryDal)genericDal;
        }

        public List<Category> GetMostRepeateds()
        {
            return _categoryDal.GetMostRepeateds();
        }
    }
}
