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
                result = igdbApi.GamesList();

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
                CallIGDBAPI igdbApi = new CallIGDBAPI();

                // Act
                var result = igdbApi.SearchByWordsInTitle(searchName);

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
                CallIGDBAPI igdbApi = new CallIGDBAPI();

                // Act
                var result = igdbApi.SearchGamesByGenre("rpg");

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
                CallIGDBAPI igdbApi = new CallIGDBAPI();

                // Act
                var result = igdbApi.SearchGamesByCollection("zelda");

                // Assert
                Assert.NotNull(result); // result is null if no game was found with matching genre
            }
        }
        [Fact]
        public void SearchGameByKeywordPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                CallIGDBAPI igdbApi = new CallIGDBAPI();

                // Act
                var result = igdbApi.SearchGamesByKeyword("action");

                // Assert
                Assert.NotNull(result); // result is null if no game was found with matching genre
            }

        }
    }
}
