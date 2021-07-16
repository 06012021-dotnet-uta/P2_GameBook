using RepositoryLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IUserFriendMethods
    {
        bool CreateFriend(User currentUser, User userToBefriend);
        bool DeleteFriend(Friend friend);
        Friend SearchFriend(int id1, int id2);
        List<Friend> FriendsList(int? userId);
    }
}