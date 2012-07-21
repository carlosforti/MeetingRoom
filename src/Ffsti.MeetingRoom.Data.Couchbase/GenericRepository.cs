using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Ffsti.MeetingRoom.Data.DataContext;
using Ffsti.MeetingRoom.Data.Interfaces;
using Ffsti.MeetingRoom.Domain.Interfaces;

namespace Ffsti.MeetingRoom.Data
{
    public class GenericRepository<C, T> : IGenericRepository<T>, IDisposable
        where T : IBaseClass
        where C : IDbContext, new()
    {
        private C entities = new C();

        public IQueryable<T> ListAll()
        {
            return this.entities.List<T>().AsQueryable<T>();
        }

        public T Find(int id)
        {
            return this.entities.FirstOrDefault(t => t.Id == id);
        }

        public void Add(T entity)
        {
            this.entities.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = this.Find(id);
            if (entity != null)
                this.entities.Remove(entity);
        }

        public void Edit(T entity)
        {
            var oldEntity = this.entities.Find(t => t.Id == entity.Id);
            this.entities.Remove(oldEntity);
            this.entities.Add(entity);
        }

        public bool Save()
        {
            return true;
        }

        public void Dispose()
        {
        }
    }
}
