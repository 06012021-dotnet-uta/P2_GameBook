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
        private readonly ILogger<PlayHistoryController> _logger;

        public PlayHistoryController(IUserPlayHistoryMethods playHistoryMethods, ILogger<PlayHistoryController> logger)
        {
            _logger = logger;
            _playHistoryMethods = playHistoryMethods;
        }
        // GET: api/<PlayHistoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PlayHistoryController>/5
        [HttpGet("{userId}/{gameId}")]
        public PlayHistory Get(int userId, int gameId)
        {
            return _playHistoryMethods.SearchPlayHistory(userId,gameId);
        }

        // POST api/<PlayHistoryController>
        [HttpPost("{userId}/{gameId}")]
        public void Post(int userId, int gameId)
        {
        }

        // DELETE api/<PlayHistoryController>/5
        [HttpDelete("{userId}/{gameId}")]
        public bool Delete(int userId, int gameId)
        {
            var result = _playHistoryMethods.SearchPlayHistory(userId, gameId);
            return _playHistoryMethods.DeletePlayHistory(result);
        }
    }
}
