using RepositoryLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IUserPlayHistoryMethods
    {
        bool CreatePlayHistory(User user, int gameId);
        bool DeletePlayHistory(PlayHistory history);
        PlayHistory SearchPlayHistory(int userid, int gameid);
        List<PlayHistory> GetUserPlayHistory(int userid);
    }
}