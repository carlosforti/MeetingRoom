using System.Linq;
using Ffsti.MeetingRoom.Data.DataContext;
using Ffsti.MeetingRoom.Data.Interfaces;
using Ffsti.MeetingRoom.Domain;

namespace Ffsti.MeetingRoom.Data
{
    public class ContactTypeRepository : GenericRepository<AppDbContext, ContactType>, IContactTypeRepository {
        public ContactType FindByName(string name)
        {
            return this.Search(c => c.Name == name).FirstOrDefault();
        }
    }
}
