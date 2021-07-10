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
        public bool CreateFriend(User user1, User user2)
        {
            bool success = false;

            try
            {
                Friend friend = new Friend()
                {
                    User1Id = user1.UserId,
                    User2Id = user2.UserId
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
        public Friend SearchFriend(int id1, int id2)
        {
            Friend temp = null;
            temp = _context.Friends.Where(x => (x.User1Id == id1 && x.User2Id == id2) || (x.User1Id == id2 && x.User2Id == id1)).FirstOrDefault();
            return temp;
        }

    } //end of class
} //end
