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
        /// <param name="currentUser">this is the ser who is trying to make a friend</param>
        /// <param name="userToBefriend">this is the user who the current user is trying to befriend</param>
        /// <returns>Returns true or false based on if save was succeful</returns>
        public bool CreateFriend(User currentUser, User userToBefriend)
        {
            bool doYouHaveFriends = DoesUserExist(userToBefriend);

            bool success = false;
            
            if (currentUser.UserId==userToBefriend.UserId || doYouHaveFriends == false)
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
                _context.Friends.Add(friend);
                _context.SaveChanges();
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
        /// <param name="friend">this will take the logged in user and pass the friend id associated to deleted it</param>
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
        public Friend SearchFriend(int id1, int id2)
        {
            Friend temp = null;
            temp = _context.Friends.Where(x => (x.User1Id == id1 && x.User2Id == id2) || (x.User1Id == id2 && x.User2Id == id1)).FirstOrDefault();
            return temp;
        }
        /// <summary>
        /// Checks if user exist
        /// </summary>
        /// <param name="user">user to check existance</param>
        /// <returns>False if friend is imaginary</returns>
        public bool DoesUserExist(User user)
		{

            try
            {
                User checkIfThere = (from c in _context.Users
                                     where c.UserId == user.UserId
                                     select c).First();

                if (checkIfThere == null)
                {
                    return false;
                }
                return true;
            }
            catch (SystemException) 
                { return false; }      

         }

		public static implicit operator UserFriendMethods(UserMethods v)
		{
			throw new NotImplementedException();
		}
	} //end of class
} //end
