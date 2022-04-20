using System;

namespace WebApplication5.Infrastructure.Domain.Users
{
    public class User
    {
        public User(string email, string firstName, string lastName, double temperature, DateTime recordDate)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Temperature = temperature;
            RecordDate = recordDate;
        }

        public int Id { get; private set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Temperature { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
