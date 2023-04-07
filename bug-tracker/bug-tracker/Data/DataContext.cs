
namespace bug_tracker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Bug> Bugs => Set<Bug>();
        public DbSet<User> Users => Set<User>();
    }
}
