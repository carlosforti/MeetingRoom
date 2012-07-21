using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Ffsti.MeetingRoom.Data.Interfaces;
using Ffsti.MeetingRoom.Service.Interfaces;
using Ffsti.MeetingRoom.Service.Validation;

namespace Ffsti.MeetingRoom.Service
{
    public abstract class BaseService<T>: IBaseService<T>
        where T: class
    {
        private IGenericRepository<T> repository;
        private IValidationDictionary validationDictionary;

        public BaseService(IValidationDictionary validationDictionary, IGenericRepository<T> repository)
        {
            this.repository = repository;
            this.validationDictionary = validationDictionary;
        }

        public virtual IQueryable<T> ListAll()
        {
            return this.repository.ListAll();
        }

        public virtual IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return this.repository.Search(predicate);
        }

        public virtual T Find(int id)
        {
            return this.repository.Find(id);
        }

        public virtual bool Add(T entity)
        {
            this.repository.Add(entity);
            return this.repository.Save();
        }

        public virtual bool Edit(T entity)
        {
            this.repository.Edit(entity);
            return this.repository.Save();
        }

        public virtual bool Delete(int id)
        {
            this.repository.Delete(id);
            return this.repository.Save();
        }

        public virtual bool Delete(T entity)
        {
            this.repository.Delete(entity);
            return this.repository.Save();
        }

        public virtual bool IsValid()
        {
            return true;
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        protected abstract bool ValidateData(T entity);
    }
}
