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
    public class PostController : ControllerBase
    {
        private readonly IUserPostingMethods _postMethods;
        private readonly IUserMethods _userMethods;
        private readonly ILogger<PostController> _logger;

        public PostController(IUserPostingMethods postMethods, IUserMethods userMethods, ILogger<PostController> logger)
        {
            _logger = logger;
            _postMethods =  postMethods;
            _userMethods = userMethods;
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return _postMethods.SearchPostById(id);
        }

        // POST api/<PostController>
        [HttpPost("user/{userId}/{content}")]
        public IActionResult PostPost(int userId, string content)
        {
            User user = _userMethods.SearchUserByID(userId);
            var result = _postMethods.CreatePost(user, content);


            if (user == null)
            {
                return StatusCode(400);
            }
            else
            {
                return StatusCode(201, result);
            }
        }

        // POST api/<PostController>
        [HttpPost("user/{userId}/parent/{parentId}/{content}")]
        public IActionResult PostComment(int userId, int parentId, string content)
        {
            User user = _userMethods.SearchUserByID(userId);
            Post parent = _postMethods.SearchPostById(parentId);
            var result = _postMethods.CreateComment(user, content, parent);


            if (user == null || parent == null)
            {
                return StatusCode(400);
            }
            else
            {
                return StatusCode(201, result);
            }
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public bool Put(int id, string contnet)
        {
            Post post = _postMethods.SearchPostById(id);
            return _postMethods.EditPost(post, contnet);
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _postMethods.DeletePost(id);
        }
    }
}
