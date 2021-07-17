using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameBook.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly PopulateDBRealQuickMethod _populateDBRealQuickMethod;
        private readonly ILogger<GameController> _logger;

        public GameController(PopulateDBRealQuickMethod populateDBRealQuickMethod, ILogger<GameController> logger)
        {
            _logger = logger;
            _populateDBRealQuickMethod = populateDBRealQuickMethod;
        }

        // GET: api/<GameController>
        [HttpGet]
        public void Get()
        {
            _populateDBRealQuickMethod.PopulateThatDb();
        }
        // GET: api/<GameController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
