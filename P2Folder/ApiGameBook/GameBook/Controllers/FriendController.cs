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
        private readonly ILogger<FriendController> _logger;

        public FriendController(IUserFriendMethods friendMethods, ILogger<FriendController> logger)
        {
            _logger = logger;
            _friendMethods = friendMethods;
        }

        // GET: api/<FriendController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FriendController>/5
        [HttpGet("{id}")]
        public List<Friend> Get(int id)
        {
            return _friendMethods.FriendsList(id);
        }

        // POST api/<FriendController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FriendController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FriendController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
