using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Ffsti.MeetingRoom.Domain;

namespace Ffsti.MeetingRoom.Data.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactType> ContactsTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public AppDbContext() : base("AppDbContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var c = modelBuilder.Conventions;
            c.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}