using RepositoryLayer;

namespace BusinessLayer
{
    public interface IUserFriendMethods
    {
        bool CreateFriend(User currentUser, User userToBefriend);
        bool DeleteFriend(Friend friend);
        Friend SearchFriend(int id1, int id2);
    }
}