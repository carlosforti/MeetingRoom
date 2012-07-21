using System.Linq;
using Ffsti.MeetingRoom.Domain.Interfaces;
namespace Ffsti.MeetingRoom.Data.Interfaces
{
    public interface IGenericRepository<T>
        where T : IBaseClass
    {
        IQueryable<T> ListAll();
        T Find(int id);
        void Add(T entity);
        void Delete(int id);
        void Edit(T entity);
        bool Save();
    }
}
