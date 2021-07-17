using Microsoft.Extensions.Logging;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GameMethods
    {
        private gamebookdbContext _context;
        private readonly ILogger<GameRatingMethods> _logger;

        public GameMethods(gamebookdbContext context)
        {
            _context = context;
        }
        public GameMethods(ILogger<GameRatingMethods> logger, gamebookdbContext context)
        {
            _logger = logger;
            _context = context;
        }
        /// <summary>
        /// Gathers all games within the database
        /// </summary>
        /// <returns>Returns list of all games</returns>
        public List<Game> GetGameList()
        {
            List<Game> list = new List<Game>();
            list = _context.Games.ToList();
            return list;
        }
        /// <summary>
        /// Searches for games based on id
        /// </summary>
        /// <returns>Returns Game that matches the gameId</returns>
        public Game SearchGame(int gameId)
        {
            Game game = new Game();
            game = _context.Games.Where(x => x.GameId == gameId).FirstOrDefault();
            return game;
        }
        /// <summary>
        /// Searches for games based on name
        /// </summary>
        /// <returns>Returns Game that matches the name</returns>
        public Game SearchGame(string name)
        {
            Game game = new Game();
            game = _context.Games.Where(x => x.Name == name).FirstOrDefault();
            return game;
        }
        /// <summary>
        /// Searches for all games based on genre 
        /// </summary>
        /// <returns>Returns List of Games that matches the genre</returns>
        public List<Game> SearchGameByGenre(string genre)
        {
            List<Game> list = new List<Game>();
            int genreId = _context.Genres.Where(x => x.Name == genre).FirstOrDefault().GenreId;
            var query = _context.Games.Join(
                _context.GenreJunctions,
                game => game.GameId,
                genreJunction => genreJunction.GameId,
                (game, genreJunction) => new
                {
                    GameId = genreJunction.GameId,
                    GenreId = genreJunction.GenreId,
                    GameName = game.Name,
                    Game = game,
                }
                ).Where(x => x.GenreId == genreId).ToList();
            for (int i = 0; i < query.Count; i++)
            {
                list.Add(query[i].Game);
            }
            return list;
        }
        /// <summary>
        /// Searches for all games based on collection 
        /// </summary>
        /// <returns>Returns List of Games that matches the collection</returns>
        public List<Game> SearchGameByCollection(string collection)
        {
            List<Game> list = new List<Game>();
            int collectionId = _context.Collections.Where(x => x.Name == collection).FirstOrDefault().CollectionId;
            var query = _context.Games.Join(
                _context.CollectionJunctions,
                game => game.GameId,
                collectionJunction => collectionJunction.GameId,
                (game, collectionJunction) => new
                {
                    GameId = collectionJunction.GameId,
                    CollectionId = collectionJunction.CollectionId,
                    GameName = game.Name,
                    Game = game,
                }
                ).Where(x => x.CollectionId == collectionId).ToList();
            for (int i = 0; i < query.Count; i++)
            {
                list.Add(query[i].Game);
            }
            return list;
        }
        /// <summary>
        /// Searches for all games based on keyword 
        /// </summary>
        /// <returns>Returns List of Games that matches the keyword</returns>
        public List<Game> SearchGameByKeyword(string keyword)
        {
            List<Game> list = new List<Game>();
            int keywordId = _context.Keywords.Where(x => x.Name == keyword).FirstOrDefault().KeywordId;
            var query = _context.Games.Join(
                _context.KeywordJunctions,
                game => game.GameId,
                keywordJunction => keywordJunction.GameId,
                (game, keywordJunction) => new
                {
                    GameId = keywordJunction.GameId,
                    KeywordId = keywordJunction.KeywordId,
                    GameName = game.Name,
                    Game = game,
                }
                ).Where(x => x.KeywordId == keywordId).ToList();
            for (int i = 0; i < query.Count; i++)
            {
                list.Add(query[i].Game);
            }
            return list;
        }

    }
}
