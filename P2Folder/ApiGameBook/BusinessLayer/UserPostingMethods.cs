using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserPostingMethods
    {
        private gamebookdbContext _context;

        public UserPostingMethods(gamebookdbContext context)
        {
            _context = context;
        }

        public int? CreatePost(User user, string content)
        {
            int? newPostId = null;
            
            // create a post by the given user with the content provided, return id of post that was just made
            // leave newPostId null if post could not be made

            return newPostId;
        }

        public bool DeletePost(int? postId)
        {
            bool success = false;

            // delete post with given id, id can be null, change success to true if successful

            return success;
        }

        public Post SearchPostById(int? postId)
        {
            Post post = null;

            // find and return post with matching id, or null if doesnt exist

            return post;
        }

        public bool EditPost(Post post, string newContent)
        {
            bool success = false;

            // change post content to newcontent and change success to true

            return success;
        }
    }
}
