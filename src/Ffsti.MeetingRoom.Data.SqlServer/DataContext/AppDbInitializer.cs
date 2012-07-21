using System.Data.Entity;

namespace Ffsti.MeetingRoom.Data.DataContext
{
    public class AppDbInitializer : DropCreateDatabaseAlways<AppDbContext>, IDatabaseInitializer<AppDbContext>
    {
        public void InitializeDatabase(AppDbContext context)
        {
            if (context.Database.Exists() && !context.Database.CompatibleWithModel(false))
                context.Database.Delete();

            if (!context.Database.Exists())
            {
                context.Database.Create();
            }
        }
    }
}