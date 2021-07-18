using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class GameMethodsTests
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb5").Options;

        [Fact]
        public void GameListPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                List<string> result;
                CallIGDBAPI igdbApi = new CallIGDBAPI();

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = igdbApi.GamesList(0);

                // Assert
                Assert.NotNull(result); // result is null if no games returned
            }
        }
        [Fact]
        public void SearchGameByIdPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                GameSearchMethods gameMethods = new GameSearchMethods(context);
                CallIGDBAPI igdbApi = new CallIGDBAPI();

                // Act
                var result = igdbApi.SearchGameById(1);

                // Assert
                Assert.NotNull(result); // result is null if no game was found with matching id
            }
        }
        [Fact]
        public void SearchGameByNamePass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                string searchName = "zelda";
                GameSearchMethods gameMethods = new GameSearchMethods(context);
                CallIGDBAPI igdbApi = new CallIGDBAPI();

                // Act
                var result = gameMethods.SearchGame(searchName);

                // Assert
                Assert.NotNull(result); // result is null if no game was found with matching name
            }
        }
        [Fact]
        public void SearchGameByGenrePass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                List<Game> result;
                Game game = new Game()
                {
                    GameId = 20,
                    Name = "Mario"
                };
                Genre genre = new Genre()
                {
                    GenreId = 20,
                    Name = "Platformer"
                };
                GenreJunction genreJunction = new GenreJunction()
                {
                    GameId = 20,
                    GenreId = 20
                };
                GameSearchMethods gameMethods = new GameSearchMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Games.Add(game);
                context.Genres.Add(genre);
                context.GenreJunctions.Add(genreJunction);
                context.SaveChanges();
                result = gameMethods.SearchGameByGenre("Platformer");

                // Assert
                Assert.NotNull(result); // result is null if no game was found with matching genre
            }
        }
        [Fact]
        public void SearchGameByCollectionPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                List<Game> result;
                Game game = new Game()
                {
                    GameId = 20,
                    Name = "Mario"
                };
                Collection collection = new Collection()
                {
                    CollectionId = 20,
                    Name = "Mario Franchise"
                };
                CollectionJunction collectionJunction = new CollectionJunction()
                {
                    GameId = 20,
                    CollectionId = 20
                };
                GameSearchMethods gameMethods = new GameSearchMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Games.Add(game);
                context.Collections.Add(collection);
                context.CollectionJunctions.Add(collectionJunction);
                context.SaveChanges();
                result = gameMethods.SearchGameByCollection("Mario Franchise");

                // Assert
                Assert.NotNull(result); // result is null if no game was found with matching collection
            }
        }
        [Fact]
        public void SearchGameByKeywordPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                List<Game> result;
                Game game = new Game()
                {
                    GameId = 20,
                    Name = "Mario"
                };
                Keyword keyword = new Keyword()
                {
                    KeywordId = 20,
                    Name = "Action"
                };
                KeywordJunction keywordJunction = new KeywordJunction()
                {
                    GameId = 20,
                    KeywordId = 20
                };
                GameSearchMethods gameMethods = new GameSearchMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Games.Add(game);
                context.Keywords.Add(keyword);
                context.KeywordJunctions.Add(keywordJunction);
                context.SaveChanges();
                result = gameMethods.SearchGameByKeyword("Action");

                // Assert
                Assert.NotNull(result); // result is null if no game was found with matching keyword
            }
        }

    }
}
