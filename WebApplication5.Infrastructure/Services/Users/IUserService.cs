using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Infrastructure.Domain.Users;

namespace WebApplication5.Infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUser(int userId);

        Task<int> CreateUser(string email, string firstName, string lastName, double temperature, DateTime recordDate);

        Task<int> UpdateUser(int userId, User user);
    }
}
