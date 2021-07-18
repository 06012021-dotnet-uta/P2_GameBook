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
        private readonly CallIGDBAPI _callIGDBAPI;
        private readonly IGameSearchMethods _gameSearchMethods;
        private readonly ILogger<GameController> _logger;

        public GameController(PopulateDBRealQuickMethod populateDBRealQuickMethod, CallIGDBAPI callIGDBAPI, IGameSearchMethods gameSearchMethods, ILogger<GameController> logger)
        {
            _logger = logger;
            _gameSearchMethods = gameSearchMethods;
            _populateDBRealQuickMethod = populateDBRealQuickMethod;
            _callIGDBAPI = callIGDBAPI;
        }

        //GET: api/<GameController>
        [HttpGet("GameList")]
        public List<string> GetGameList()
        {
            return _callIGDBAPI.GamesList();
        }

        // GET api/<GameController>/5
        [HttpGet("title/{words}")]
        public List<string> GetGamesByWordsInTitle(string words)
        {
            return _callIGDBAPI.SearchByWordsInTitle(words);
        }

        [HttpGet("genre/{genre}")]
        public List<string> GetGamesByGenre(string genre)
        {
          
            return _callIGDBAPI.SearchGamesByGenre(genre);
        }

        [HttpGet("Series/{series}")]
        public List<string> GetGamesBySeries(string series)
        {

            return _callIGDBAPI.SearchGamesByCollection(series);
        }

        [HttpGet("KeyWord/{keyword}")]
        public List<string> GetGamesByKeyWord(string keyword)
        {
            // can't get it to work please fix
            return _callIGDBAPI.SearchGamesByKeyword(keyword);
        }

        [HttpGet("GameID/{gameID}")]
        public string GetGamesById(int gameID)
        {
            // can't get it to work please fix
            return _callIGDBAPI.SearchGameById(gameID);
        }

        [HttpGet("pix/{gameID}")]
        public List<string> GetGamePix(int gameID)
        {
            // can't get it to work please fix
            return _callIGDBAPI.PicturesForTheGame(gameID);
        }
    }
}
