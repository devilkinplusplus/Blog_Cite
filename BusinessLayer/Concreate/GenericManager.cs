using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            this._genericDal = genericDal;
        }

        public void TAdd(T t)
        {
            _genericDal.Insert(t);
        }

        public void TDelete(T t)
        {
            _genericDal.Delete(t);
        }

        public T TGetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public List<T> TGetList()
        {
            return _genericDal.GetListAll();
        }

        public void TUpdate(T t)
        {
            _genericDal.Update(t);
        }
    }
}
