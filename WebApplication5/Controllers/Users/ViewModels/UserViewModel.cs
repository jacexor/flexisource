using System;
using WebApplication5.Infrastructure.Domain.Users;

namespace WebApplication5.Controllers.Users.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Temperature = user.Temperature;
            RecordDate = user.RecordDate;
        }


        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Temperature { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
