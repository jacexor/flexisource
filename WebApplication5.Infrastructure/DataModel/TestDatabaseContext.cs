using Microsoft.EntityFrameworkCore;
using WebApplication5.Infrastructure.DataModel.Configurations;
using WebApplication5.Infrastructure.Domain.Users;

namespace WebApplication5.Infrastructure.DataModel
{
    public class TestDatabaseContext : DbContext
    {
        public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
