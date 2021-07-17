using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserFriendMethods : IUserFriendMethods
    {
        private gamebookdbContext _context;
        private readonly ILogger<UserFriendMethods> _logger;

        public UserFriendMethods(gamebookdbContext context)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            _logger = factory.CreateLogger<UserFriendMethods>();
            _context = context;
        }
        public UserFriendMethods(ILogger<UserFriendMethods> logger, gamebookdbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Friend> FriendsList(int? userId)
        {
            List<Friend> friendsList = null;
            try
            {
                friendsList = _context.Friends.Where(x => (x.User1Id == userId || x.User2Id == userId)).ToList();
                if (friendsList.Count < 1)
                    _logger.LogWarning("WARNING: Friends list is empty");
                return friendsList;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return friendsList;
            }
        }

        /// <summary>
        /// This checks if friend exist then adds to database the id of friend in friend
        /// </summary>
        /// <param name="currentUser">This is the user who is trying to make a friend</param>
        /// <param name="userToBefriend">This is the user who the current user is trying to befriend</param>
        /// <returns>Returns true or false based on if save was succeful</returns>
        public bool CreateFriend(User currentUser, User userToBefriend)
        {
            bool success = false;

            try
            {
                if (currentUser == null || userToBefriend == null)
                {
                    _logger.LogError("ERROR: null user");
                    return false;
                }
                if (currentUser.UserId == userToBefriend.UserId)
                {
                    _logger.LogError("ERROR: Users must be different");
                    return false;
                }
                Friend friend = new Friend()
                {
                    User1Id = currentUser.UserId,
                    User2Id = userToBefriend.UserId
                };
                _context.Friends.Add(friend);
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
        /// DeleteFriend removes the id of a friend from your database however this has no effect if they friended you
        /// </summary>
        /// <param name="friend">This will take the logged in user and pass the friend id associated to deleted it</param>
        /// <returns>True if succesfull else false</returns>
        public bool DeleteFriend(Friend friend)
        {
            bool success = false;
            try
            {
                _context.Remove(friend);
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
        /// looks for users based on id
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public Friend SearchFriend(int id1, int id2)
        {
            Friend temp = null;
            temp = _context.Friends.Where(x => (x.User1Id == id1 && x.User2Id == id2) || (x.User1Id == id2 && x.User2Id == id1)).FirstOrDefault();
            if (temp == null)
                _logger.LogWarning("WARNING: Friend pair not found");
            return temp;
        }
    } //end of class
} //end
