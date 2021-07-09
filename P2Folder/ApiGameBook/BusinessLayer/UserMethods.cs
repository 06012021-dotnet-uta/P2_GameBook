using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserMethods
    {
        private gamebookdbContext _context;

        public UserMethods(gamebookdbContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            bool success = false;

            try
            {
                var username = _context.Users.Where(x => x.Username == user.Username).FirstOrDefault(); //Find if a username is already taken
                if (username == null)
                {
                    // add user to db, change success to true if successful
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    success = true;
                    return success;
                }
                else
                {
                    Console.WriteLine("Error, that username already exists");
                }
            }
            catch
            {
                Console.WriteLine("Error, user not created");
            }

            return success;

        }

        public bool DeleteUser(User user)
        {
            bool success = false;

            try
            {
                // delete user from db, change success to true if successful
                _context.Users.Remove(user);
                _context.SaveChanges();
                success = true;
                return success;
            }
            catch
            {
                Console.WriteLine("Error, user not deleted");
            }

            return success;
        }

        public User SearchUserByUsername(string username)
        {
            User temp = null;

            // Search users table for user with matching name, returns null if not found
            temp = _context.Users.Where(x => x.Username == username).FirstOrDefault();

            return temp;
        }
    }
}
