using Model;
using System.Data.Entity;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDbContext")
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>().ToTable("Link", "sl");
        }

    }
}
