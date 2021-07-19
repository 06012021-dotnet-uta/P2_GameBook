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
    public class PlayHistoryController : ControllerBase
    {
        private readonly IUserPlayHistoryMethods _playHistoryMethods;
        private readonly IUserMethods _userMethods;
        private readonly ILogger<PlayHistoryController> _logger;

        public PlayHistoryController(IUserPlayHistoryMethods playHistoryMethods, IUserMethods userMethods, ILogger<PlayHistoryController> logger)
        {
            _logger = logger;
            _playHistoryMethods = playHistoryMethods;
            _userMethods = userMethods;
        }
        // GET: api/<PlayHistoryController>
        [HttpGet("{userId}")]
        public List<PlayHistory> Get(int userId)
        {
            return _playHistoryMethods.GetUserPlayHistory(userId);
        }

        // GET api/<PlayHistoryController>/user/5/game/1
        [HttpGet("user/{userId}/game/{gameId}")]
        public PlayHistory Get(int userId, int gameId)
        {
            return _playHistoryMethods.SearchPlayHistory(userId,gameId);
        }

        // POST api/<PlayHistoryController>
        [HttpPost("user/{userId}/game/{gameId}")]
        public bool Post(int userId, int gameId)
        {
            return _playHistoryMethods.CreatePlayHistory(_userMethods.SearchUserByID(userId), gameId);
        }

        // DELETE api/<PlayHistoryController>/5
        [HttpDelete("user/{userId}/game/{gameId}")]
        public bool Delete(int userId, int gameId)
        {
            var result = _playHistoryMethods.SearchPlayHistory(userId, gameId);
            return _playHistoryMethods.DeletePlayHistory(result);
        }
    }
}
