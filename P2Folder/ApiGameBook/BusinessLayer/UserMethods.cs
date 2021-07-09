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

            // add user to db, change success to true if successful

            return success;
        }

        public bool DeleteUser(User user)
        {
            bool success = false;

            // delete user from db, change success to true if successful

            return success;
        }

        public User SearchUserByUsername(string username)
        {
            User temp = null;

            // Search users table for user with matching name, returns null if not found

            return temp;
        }
    }
}
