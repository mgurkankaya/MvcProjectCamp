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
            _object = c.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        void IRepository<T>.Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        void IRepository<T>.Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
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
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();

        }
    }
}
