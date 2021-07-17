using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserPostingMethods: IUserPostingMethods
    {
        private gamebookdbContext _context;
        private readonly ILogger<UserPostingMethods> _logger;

        public UserPostingMethods(gamebookdbContext context)
        {
            _context = context;
        }
        public UserPostingMethods(ILogger<UserPostingMethods> logger, gamebookdbContext context)
        {
            _logger = logger;
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
            // leaves newPostId null if post could not be made
            try
            {
                if (content == null || content == "") //Tests if user is trying to create a post with no content
                {
                    _logger.LogWarning("WARNING: User must add content to create post");
                }
                else if(content.Length>=1000)
                {
                    _logger.LogWarning("WARNING: Content too long.");
                }
                else
                {
                    Post newPost = new Post();
                    newPost.UserId = user.UserId;
                    newPost.Content = content;
                    newPost.PostDate = DateTime.Now;

                    _context.Posts.Add(newPost);
                    _context.SaveChanges();
                    newPostId = newPost.PostId;
                    return newPostId;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
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
            try
            {
                Post post = SearchPostById(postId);
                _context.Posts.Remove(post);
                _context.SaveChanges();
                success = true;
                return success;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
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
            try
            {
                post = _context.Posts.Where(x => x.PostId == postId).FirstOrDefault();
                if (post == null)
                    _logger.LogWarning("WARNING: Post not found");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
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
            try
            {
                // search to see if post exists
                if (SearchPostById(post.PostId) == null)
                {
                    _logger.LogWarning("WARNING: Post could not be found");
                    return success;
                }
                else if(newContent == "" || newContent == null)
                {
                    _logger.LogWarning("WARNING: Must include content with edit");
                }
                else if(newContent == post.Content)
                {
                    _logger.LogWarning("WARNING: Post content must be different");
                }
                else
                {
                    post.Content = newContent;
                    _context.Posts.Update(post); // update post and save changes to db
                    _context.SaveChanges();
                    success = true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
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
            // leaves newPostId null if post could not be made
            try
            {
                if (content == null || content == "") //Tests if user is trying to create a post with no content
                {
                    _logger.LogWarning("WARNING: User must add content to create comment");
                }
                else if (content.Length >= 1000)
                {
                    _logger.LogWarning("WARNING: Content too long.");
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
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return newPostId;
        }
    }
}
