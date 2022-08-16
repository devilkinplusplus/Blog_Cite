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
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(IGenericDal<Comment> genericDal) : base(genericDal)
        {
            this._commentDal = (ICommentDal)genericDal;
        }

        public List<Comment> GetCommentsByBlog(int id)
        {
            return _commentDal.GetCommentsByBlog(id);
        }
    }
}
