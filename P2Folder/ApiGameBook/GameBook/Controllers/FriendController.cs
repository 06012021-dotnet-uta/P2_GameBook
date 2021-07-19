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

        // GET api/<FriendController>/list/5
        [HttpGet("list/{id}")]
        public List<string> Get(int id)
        {
            List<Friend> friends = _friendMethods.FriendsList(id);
            List<string> usernames = new List<string>();

            foreach(var friend in friends)
            {
                if (friend.User1Id == id)
                    usernames.Add(_userMethods.SearchUserByID(friend.User2Id).Username);
                else if(friend.User2Id == id)
                    usernames.Add(_userMethods.SearchUserByID(friend.User1Id).Username);
            }

            return usernames;
        }

        // POST api/<FriendController>/1/5
        [HttpPost("{user1id}/{user2id}")]
        public bool Post(int user1id, int user2id)
        {
            return _friendMethods.CreateFriend(_userMethods.SearchUserByID(user1id), _userMethods.SearchUserByID(user2id));
        }

        // DELETE api/<FriendController>/delete/5/1
        [HttpDelete(("delete/{user1id}/{user2id}"))]
        public bool Delete(int user1id, int user2id)
        {
            Friend friend = _friendMethods.SearchFriend(user1id, user2id);
            return _friendMethods.DeleteFriend(friend);
        }
    }
}
