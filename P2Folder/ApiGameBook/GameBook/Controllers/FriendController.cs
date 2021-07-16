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
    public class FriendController : ControllerBase
    {

        private readonly IUserFriendMethods _friendMethods;
        private readonly IUserMethods _userMethods;
        private readonly ILogger<FriendController> _logger;

        public FriendController(IUserFriendMethods friendMethods, IUserMethods userMethods, ILogger<FriendController> logger)
        {
            _logger = logger;
            _friendMethods = friendMethods;
            _userMethods = userMethods;
        }

        // GET: api/<FriendController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<FriendController>/5
        [HttpGet("{id}")]
        public List<Friend> Get(int id)
        {
            return _friendMethods.FriendsList(id);
        }

        // POST api/<FriendController>/1/5
        [HttpPost("{user1id}/{user2id}")]
        public bool Post(int user1id, int user2id)
        {
            return _friendMethods.CreateFriend(_userMethods.SearchUserByID(user1id), _userMethods.SearchUserByID(user2id));
        }

        // PUT api/<FriendController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<FriendController>/5/1
        [HttpDelete(("{user1id}/{user2id}"))]
        public bool Delete(int user1id, int user2id)
        {
            Friend friend = _friendMethods.SearchFriend(user1id, user2id);
            return _friendMethods.DeleteFriend(friend);
        }
    }
}
