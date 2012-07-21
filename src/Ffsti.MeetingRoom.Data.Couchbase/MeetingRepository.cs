using Ffsti.MeetingRoom.Data.DataContext;
using Ffsti.MeetingRoom.Data.Interfaces;
using Ffsti.MeetingRoom.Domain;

namespace Ffsti.MeetingRoom.Data
{
    public class MeetingRepository : GenericRepository<AppDbContext, Meeting>, IMeetingRepository { }
}
