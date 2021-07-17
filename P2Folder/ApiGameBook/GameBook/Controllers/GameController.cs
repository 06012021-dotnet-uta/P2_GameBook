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
    public class GameController : ControllerBase
    {
        private readonly PopulateDBRealQuickMethod _populateDBRealQuickMethod;
        private readonly IGameSearchMethods _gameSearchMethods;
        private readonly ILogger<GameController> _logger;

        public GameController(PopulateDBRealQuickMethod populateDBRealQuickMethod, IGameSearchMethods gameSearchMethods, ILogger<GameController> logger)
        {
            _logger = logger;
            _gameSearchMethods = gameSearchMethods;
            _populateDBRealQuickMethod = populateDBRealQuickMethod;
        }

        //GET: api/<GameController>
        [HttpGet]
        public List<Game> Get()
        {
            return _gameSearchMethods.GetGameList();
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public Game Get(int id)
        {
            return _gameSearchMethods.SearchGame(id);
        }

        //// GET api/<GameController>/rpg
        //[HttpGet("{keyword}")]
        //public List<Game> Get(string keyword)
        //{
        //    return _gameSearchMethods.SearchGameByKeyword(keyword);
        //}

        // POST api/<GameController>
        [HttpPost]
        public void Post()
        {
            // this method is only called to seed the database, comment out after we are done with it?
            _populateDBRealQuickMethod.PopulateThatDb();
        }

        //// PUT api/<GameController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GameController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
