using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApplication5.Infrastructure.Domain.Users;

namespace WebApplication5.Infrastructure.DataModel
{
    public class InitialDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TestDatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<TestDatabaseContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }

                context.Users.AddRange(
                    new User("test1@test.com", "J", "Maniquis", 36.1, DateTime.Now),
                    new User("test2@test.com", "MengKen", "hur", 36.2, DateTime.Now),
                    new User("test3@test.com", "Sum", "Ting Wong", 36.3, DateTime.Now),
                    new User("test4@test.com", "Master", "Gates", 36.4, DateTime.Now)
                );

                context.SaveChanges();
            }
        }
    }
}
