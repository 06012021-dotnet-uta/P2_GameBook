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
    public class RatingController : ControllerBase
    {
        private readonly IGameRatingMethods _gameRatingMethods;
        private readonly ILogger<RatingController> _logger;

        public RatingController(IGameRatingMethods gameRatingMethods, ILogger<RatingController> logger)
        {
            _logger = logger;
            _gameRatingMethods = gameRatingMethods;
        }

        // GET: api/<RatingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RatingController>/5
        [HttpGet("{userId}/{gameId}")]
        public Rating Get(int userId, int gameId)
        {
            return _gameRatingMethods.SearchRatings(userId, gameId);
        }

        // POST api/<RatingController>
        [HttpPost("{userId}/{gameId}/{rating}")]
        public void Post(int userId, int gameId, int rating)
        {
        }

        // PUT api/<RatingController>/5
        [HttpPut("{userId}/{gameId}/{rating}")]
        public void Put(int userId, int gameId, int rating)
        {
        }

        // DELETE api/<RatingController>/5
        [HttpDelete("{userId}/{gameId}")]
        public bool Delete(int userId, int gameId)
        {
            var result = _gameRatingMethods.SearchRatings(userId, gameId);
            return _gameRatingMethods.DeleteRating(result);
        }
    }
}
