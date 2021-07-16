using RepositoryLayer;

namespace BusinessLayer
{
    public interface IUserPlayHistoryMethods
    {
        bool CreatePlayHistory(User user, Game game);
        bool DeletePlayHistory(PlayHistory history);
        PlayHistory SearchPlayHistory(int userid, int gameid);
    }
}