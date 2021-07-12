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

        public int? CreatePost(User user, string content) //Create a Post with no rating attached
        {
            int? newPostId = null;
            // create a post by the given user with the content provided, return id of post that was just made
            // leaves newPostId null if post could not be made
            
            try
            {
                if (content == null || content == "") //Tests if user is trying to create a post with no content
                {
                    Console.WriteLine("User must add content to create post");
                }
                else if(content.Length>=1000)
                {
                    Console.WriteLine("Content too long.");
                }
                else
                {
                    Post newPost = new Post();
                    newPost.UserId = user.UserId;


                    newPost.Content = content;
                    newPost.PostDate = DateTime.Now; // database setup to automatically add date, we can remove this if types are not matching up

                    _context.Posts.Add(newPost);
                    _context.SaveChanges();

                    newPostId = newPost.PostId; 

                    return newPostId;
                }
            }
            catch
            {
                Console.WriteLine("Error, post not created");
            }

            return newPostId;
        }

        public bool DeletePost(int? postId)
        {
            bool success = false;

            // delete post with given id, id can be null, change success to true if successful

            try
            {
                Post post  = SearchPostById(postId);

                _context.Posts.Remove(post);
                _context.SaveChanges();
                success = true;
                return success;
            }
            catch
            {
                Console.WriteLine("Error, post not deleted");
            }

            return success;
        }

        public Post SearchPostById(int? postId)
        {
            Post post = null;

            // find and return post with matching id, or null if doesnt exist
            post = _context.Posts.Where(x => x.PostId == postId).FirstOrDefault();

            return post;
        }

        public bool EditPost(Post post, string newContent)
        {
            bool success = false;

            // change post content to newcontent and change success to true
            try
            {
                // search to see if post exists
                if (SearchPostById(post.PostId) == null)
                {
                    Console.WriteLine("Post could not be found");
                    return success;
                }
                else if(newContent == "" || newContent == null)
                {
                    Console.WriteLine("Must include content with edit");
                }
                else if(newContent == post.Content)
                {
                    Console.WriteLine("Post content must be different");
                }
                else
                {
                    post.Content = newContent;
                    _context.Posts.Update(post); // update post and save changes to db
                    _context.SaveChanges();
                    success = true;
                }
            }
            catch
            {
                Console.WriteLine("Error, post not edited");
            }

            return success;
        }
    }
}
