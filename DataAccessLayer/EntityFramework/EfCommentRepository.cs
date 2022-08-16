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
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        Context c = new Context();
        public List<Comment> GetCommentsByBlog(int id)
        {
            return c.Comments.Include(x=>x.Writer).Where(x => x.BlogID == id).ToList();
        }
    }
}
