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
    public class BlogManager:GenericManager<Blog>,IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IGenericDal<Blog> genericDal) : base(genericDal)
        {
            _blogDal = (IBlogDal)genericDal;
        }

        public List<Blog> GetBlogByIdWithCategory(int id)
        {
            return _blogDal.GetBlogByIdWithCategory(id);
        }

        public List<Blog> GetBlogsWithCategory()
        {
            return _blogDal.GetBlogsWithCategory();
        }

        public List<Blog> GetBlogsWithCategoryByWriter(int id)
        {
            return _blogDal.GetBlogsWithCategoryByWriter(id);
        }

        public List<Blog> GetOtherBlogsByWriter(int id)
        {
            return _blogDal.GetOtherBlogsByWriter(id);
        }
    }
}
