using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserFriendMethods
    {
        private gamebookdbContext _context;

        public UserFriendMethods(gamebookdbContext context)
        {
            _context = context;
        }
        // Create Friend from two users

        /// <summary>
        /// This checks if friend exist then adds to database the id of friend in friend
        /// </summary>
        /// <param name="currentUser">This is the user who is trying to make a friend</param>
        /// <param name="userToBefriend">This is the user who the current user is trying to befriend</param>
        /// <returns>Returns true or false based on if save was succeful</returns>
        public async Task<bool> CreateFriendAsync(User currentUser, User userToBefriend)
        {

            bool success = false;

            if (currentUser.UserId == userToBefriend.UserId)
            {
                return false;
            }
            try
            {
                Friend friend = new Friend()
                {
                    User1Id = currentUser.UserId,
                    User2Id = userToBefriend.UserId
                };
                await _context.Friends.AddAsync(friend);
                await _context.SaveChangesAsync();
                success = true;
                return success;
            }
            catch
            {
                Console.WriteLine("Error, friend not added");
            }

            return success;
        }
        /// <summary>
        /// DeleteFriend removes the id of a friend from your database however this has no effect if they friended you
        /// </summary>
        /// <param name="friend">This will take the logged in user and pass the friend id associated to deleted it</param>
        /// <returns>True if succesfull else false</returns>
        public async Task<bool> DeleteFriendAsync(Friend friend)
        {
            bool success = false;
            try
            {
                _context.Remove(friend);
                await _context.SaveChangesAsync();
                success = true;
                return success;
            }
            catch
            {
                Console.WriteLine("Error, friend not removed");
            }
            return success;
        }
        /// <summary>
        /// looks for users based on id
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public async Task<Friend> SearchFriendAsync(int id1, int id2)
        {
            Friend temp = null;
            temp = await _context.Friends.Where(x => (x.User1Id == id1 && x.User2Id == id2) || (x.User1Id == id2 && x.User2Id == id1)).FirstOrDefaultAsync();
            return temp;
        }
	} //end of class
} //end
