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
        /// <summary>
        /// Adds a post
        /// </summary>
        /// <param name="user">The user commenting</param>
        /// <param name="content">The users comment</param>
        /// <returns>The post ID is returned</returns>
        public int? CreatePost(User user, string content) //Create a Post 
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

        /// <summary>
        /// Delete's post that are made
        /// </summary>
        /// <param name="postId">The post id</param>
        /// <returns>Deletes if true</returns>
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

        /// <summary>
        /// Searches post by ID
        /// </summary>
        /// <param name="postId">Takes the id your looking for</param>
        /// <returns>True if able to find</returns>
        public Post SearchPostById(int? postId)
        {
            Post post = null;

            // find and return post with matching id, or null if doesnt exist
            post = _context.Posts.Where(x => x.PostId == postId).FirstOrDefault();

            return post;
        }
        /// <summary>
        /// Allows the ability to edit post
        /// </summary>
        /// <param name="post">The original post object</param>
        /// <param name="newContent">The edited comment</param>
        /// <returns>true if able to return</returns>
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
        /// <summary>
        /// Creates a user comment
        /// </summary>
        /// <param name="user">The user commenting</param>
        /// <param name="content">The content of the comment</param>
        /// <param name="parent">The parent comment</param>
        /// <returns>returns the post id</returns>
        public int? CreateComment(User user, string content, Post parent) //Create a Comment
        {
            int? newPostId = null;
            // create a comment by the given user with the content provided, return id of post that was just made
            // leaves newPostId null if post could not be made

            try
            {
                if (content == null || content == "") //Tests if user is trying to create a post with no content
                {
                    Console.WriteLine("User must add content to create comment");
                }
                else if (content.Length >= 1000)
                {
                    Console.WriteLine("Content too long.");
                }
                else
                {
                    Post newComment = new Post();
                    newComment.UserId = user.UserId;

                    newComment.CommentParentId = parent.PostId;
                    newComment.Content = content;
                    newComment.PostDate = DateTime.Now; // database setup to automatically add date, we can remove this if types are not matching up

                    _context.Posts.Add(newComment);
                    _context.SaveChanges();

                    newPostId = newComment.PostId;

                    return newPostId;
                }
            }
            catch
            {
                Console.WriteLine("Error, comment not created");
            }

            return newPostId;
        }
    }
}
