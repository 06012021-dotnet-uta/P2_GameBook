using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IGameSearchMethods
    {
        List<Game> GetGameList();
        Game SearchGame(int gameId);
        Game SearchGame(string name);
        List<Game> SearchGameByGenre(string genre);
        List<Game> SearchGameByCollection(string collection);
        List<Game> SearchGameByKeyword(string keyword);

    }
}
