using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Ffsti.MeetingRoom.Domain;

namespace Ffsti.MeetingRoom.Data.DataContext
{
    public class AppDbContext: IDbContext
    {
        public List<ContactType> ContactsTypes { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Meeting> Meetings { get; set; }
        public List<Room> Rooms { get; set; }
    }
}