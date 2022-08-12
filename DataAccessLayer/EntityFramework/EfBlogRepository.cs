using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        Context c = new Context();
        public List<Blog> GetBlogsWithCategoryByWriter(int id)
        {
            return c.Blogs.Include(x => x.Category).Where(x=>x.WriterId==id).ToList();
        }
    }
}
