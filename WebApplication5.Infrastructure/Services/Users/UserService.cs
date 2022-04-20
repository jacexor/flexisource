using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Infrastructure.DataModel;
using WebApplication5.Infrastructure.Domain.Users;

namespace WebApplication5.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly TestDatabaseContext _context;

        public UserService(TestDatabaseContext context)
        {
            _context = context;
        }

        public Task<int> CreateUser(string email, string firstName, string lastName, double temperature, DateTime recordDate)
        {
            using (TestDatabaseContext con = _context)
            {
                con.Users.Add(new User(email, firstName, lastName, temperature, recordDate));

                return con.SaveChangesAsync(true);
            }
        }

        public Task<List<User>> GetAllUsers()
        {
            using (TestDatabaseContext con = _context)
            {
                return con.Users.ToListAsync();
            }
        }

        public Task<User> GetUser(int userId)
        {
            using (TestDatabaseContext con = _context)
            {
                return con.Users.FirstOrDefaultAsync(p => p.Id == userId);
            }
        }

        public Task<int> UpdateUser(int userId, User user)
        {
            using (TestDatabaseContext con = _context)
            {
                var usr = con.Users.Find(userId);
                if (usr != null)
                {
                    usr.FirstName = user.FirstName;
                    usr.Email = user.Email;
                    usr.LastName = user.LastName;
                    usr.RecordDate = user.RecordDate;
                    usr.Temperature = user.Temperature;
                    con.Users.Update(usr);

                    return con.SaveChangesAsync(true);
                }

                return Task.FromResult(0);
            }
        }
    }
}
