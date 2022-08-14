using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        Context c = new Context();
        public List<Category> GetMostRepeateds()
        {
            //Randomly
            Random rand = new Random();
            int toSkip = rand.Next(1, c.Categories.Count());
            var randomObject = c.Categories.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(3).ToList();
            return randomObject;
        }
    }
}
