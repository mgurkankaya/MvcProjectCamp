using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object=c.Set<T>();
        }

        void IRepository<T>.Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        void IRepository<T>.Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        List<T> IRepository<T>.List()
        {
           return _object.ToList();
        }

        List<T> IRepository<T>.List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        void IRepository<T>.Update(T p)
        {
            c.SaveChanges();
        }
    }
}
