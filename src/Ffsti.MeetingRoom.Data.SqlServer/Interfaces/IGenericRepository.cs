using System;
using System.Linq;
using System.Linq.Expressions;
namespace Ffsti.MeetingRoom.Data.Interfaces
{
    public interface IGenericRepository<T> : IDisposable
        where T : class
    {
        IQueryable<T> ListAll();
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);
        T Find(int id);
        void Add(T entity);
        void Delete(int id);
        void Delete(T entity);
        void Edit(T entity);
        bool Save();
    }
}
