using System.Collections.Generic;
using RepositoryLayer;

namespace BusinessLayer
{
    public interface IUserMethods
    {
        bool CreateUser(User user);
        bool DeleteUser(User user);
        bool EditUser(User oldUser, User newUser);
        User SearchUserByID(int userId);
        User SearchUserByUsername(string username);
        List<User> UsersList();
    }
}