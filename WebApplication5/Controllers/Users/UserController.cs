using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Controllers.Users.InputModels;
using WebApplication5.Controllers.Users.ViewModels;
using WebApplication5.Infrastructure.Domain.Users;
using WebApplication5.Infrastructure.Services.Users;

namespace WebApplication5.Controllers.Users
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("")]
        public async Task<ActionResult<List<UserViewModel>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            var result = new List<UserViewModel>();
            foreach (var user in users)
            {
                result.Add(new UserViewModel(user));
            }

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserViewModel>> GetUser([FromRoute] int userId)
        {
            var user = await _userService.GetUser(userId);
            if (user == null)
                return NotFound();

            return Ok(new UserViewModel(user));
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateUser([FromBody] UserInputModel user)
        {
            double temp;
            double.TryParse(user.Temperature, out temp);
            var result = await _userService.CreateUser(user.Email, user.FirstName, user.LastName, temp, DateTime.Now);
            if (result < 1)
                return BadRequest();

            return Ok();
        }

        [HttpPut("")]
        public async Task<ActionResult> UpdateUser([FromBody] UserUpdateModel user)
        {
            double temp;
            int userId;
            double.TryParse(user.Temperature, out temp);
            int.TryParse(user.UserId, out userId);
            var result = await _userService.UpdateUser(userId, new User(user.Email, user.FirstName, user.LastName, temp, DateTime.Now));
            if (result < 1)
                return BadRequest();

            return Ok();
        }
    }
}
