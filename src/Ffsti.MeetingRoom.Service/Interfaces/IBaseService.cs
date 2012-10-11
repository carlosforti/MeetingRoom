using System;
using System.Linq;
using System.Linq.Expressions;
namespace Ffsti.MeetingRoom.Service.Interfaces
{
    public interface IBaseService<T>: IDisposable
        where T : class
    {
        IQueryable<T> ListAll();
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);
        T Find(int id);
        bool Add(T entity);
        bool Edit(T entity);
        bool Delete(int id);
        bool Delete(T entity);
        bool IsValid(T entity);
    }
}
