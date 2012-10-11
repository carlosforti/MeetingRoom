using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Ffsti.MeetingRoom.Data.Interfaces;

namespace Ffsti.MeetingRoom.Data
{
    public class GenericRepository<C, T> : IGenericRepository<T>, IDisposable
        where T : class, new()
        where C : DbContext, new()
    {
        private C entities = new C();

        public C Entities
        {
            get { return entities; }
            set { entities = value; }
        }

        public virtual IQueryable<T> ListAll()
        {
            return this.entities.Set<T>().AsQueryable<T>();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return this.entities.Set<T>().Where(predicate);
        }

        public T Find(int id)
        {
            return this.entities.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            this.entities.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = this.Find(id);
            if (entity != null)
                this.entities.Set<T>().Remove(entity);
        }

        public void Delete(T entity)
        {
            this.entities.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            this.entities.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public bool Save()
        {
            return (this.entities.SaveChanges() > 0);
        }

        public void Dispose()
        {
            this.entities.Dispose();
        }
    }
}
