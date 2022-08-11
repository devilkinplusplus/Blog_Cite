using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context cont = new Context();
        public void Delete(T t)
        {
            cont.Remove(t);
            cont.SaveChanges();
        }

        public T GetById(int id)
        {
            return cont.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return cont.Set<T>().ToList();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return cont.Set<T>().Where(filter).ToList();
        }

        public void Insert(T t)
        {
            cont.Add(t);
            cont.SaveChanges();
        }

        public void Update(T t)
        {
            cont.Update(t);
            cont.SaveChanges();
        }
    }
}
