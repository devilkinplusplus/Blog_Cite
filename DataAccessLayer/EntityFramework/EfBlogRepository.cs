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

        public List<Blog> GetBlogByIdWithCategory(int id)
        {
            return c.Blogs.Include(x => x.Category).Where(x => x.BlogID == id).ToList();
        }

        public List<Blog> GetBlogsWithCategory()
        {
            return c.Blogs.Include(x => x.Category).ToList();
        }

        public List<Blog> GetBlogsWithCategoryByWriter(int id)
        {
            return c.Blogs.Include(x => x.Category).Where(x=>x.WriterId==id).ToList();
        }

        public List<Blog> GetOtherBlogsByWriter(int id)
        {
            return c.Blogs.Where(x => x.WriterId == id).ToList();
        }
    }
}
