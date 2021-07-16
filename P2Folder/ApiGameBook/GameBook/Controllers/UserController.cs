using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserMethods _userMethods;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserMethods userMethods, ILogger<UserController> logger)
        {
            _logger = logger;
            _userMethods = userMethods;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            return _userMethods.UsersList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userMethods.SearchUserByID(id);
        }

        // POST api/<UserController>
        [HttpPost("{username}/{password}/{firstName}/{lastName}/{email}")]
        public bool Post(string username, string password, string firstName, string lastName, string email)
        {
            User user = new User()
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
            return _userMethods.CreateUser(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}/{username}/{password}/{firstName}/{lastName}/{email}")]
        public bool Put(int id, string username, string password, string firstName, string lastName, string email)
        {
            User newUser = new User()
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            var oldUser = _userMethods.SearchUserByID(id);

            return _userMethods.EditUser(oldUser, newUser);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            User user = _userMethods.SearchUserByID(id); 
            return _userMethods.DeleteUser(user);
        }
    }
}
