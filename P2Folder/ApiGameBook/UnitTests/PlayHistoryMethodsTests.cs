using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class PlayHistoryMethodsTests
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb1").Options;

        [Fact]
        public async Task CreatePlayHistoryPassAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user = new User()
                {
                    Username = "user",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                Game game = new Game()
                {
                    Name = "name"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPlayHistoryMethods playHistoryMethods = new UserPlayHistoryMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Games.Add(game);
                context.SaveChanges();
                await userMethods .CreateUserAsync(user);
                result = await playHistoryMethods.CreatePlayHistoryAsync(user, game);

                // Assert
                Assert.True(result); // result should be true if creation of a new play history entry was successful
            }
        }

        [Fact]
        public async Task CreatePlayHistoryGameNotFoundAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user = new User()
                {
                    Username = "user",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                Game game = new Game()
                {
                    Name = "name"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPlayHistoryMethods playHistoryMethods = new UserPlayHistoryMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                await userMethods.CreateUserAsync(user);
                result = await playHistoryMethods.CreatePlayHistoryAsync(user, game);

                // Assert
                Assert.False(result); // result should be false if game not found in db
            }
        }

        [Fact]
        public async Task CreatePlayHistoryUserNotFoundAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user = new User()
                {
                    Username = "user",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                Game game = new Game()
                {
                    Name = "name"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPlayHistoryMethods playHistoryMethods = new UserPlayHistoryMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Games.Add(game);
                context.SaveChanges();
                result = await playHistoryMethods.CreatePlayHistoryAsync(user, game);

                // Assert
                Assert.False(result); // result should be false if user not found in db
            }
        }

        [Fact]
        public async Task DeletePlayHistoryPassAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user = new User()
                {
                    Username = "user",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                Game game = new Game()
                {
                    Name = "name"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPlayHistoryMethods playHistoryMethods = new UserPlayHistoryMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Games.Add(game);
                context.SaveChanges();
                await userMethods.CreateUserAsync(user);
                await playHistoryMethods.CreatePlayHistoryAsync(user, game);
                result = await playHistoryMethods.DeletePlayHistoryAsync(await playHistoryMethods.SearchPlayHistoryAsync(user.UserId, game.GameId));

                // Assert
                Assert.True(result); // result should be true if deletion of a play history entry was successful
            }
        }

        [Fact]
        public async Task DeletePlayHistoryNotFoundAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user = new User()
                {
                    Username = "user",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                Game game = new Game()
                {
                    Name = "name"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPlayHistoryMethods playHistoryMethods = new UserPlayHistoryMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Games.Add(game);
                context.SaveChanges();
                await userMethods.CreateUserAsync(user);
                result = await playHistoryMethods.DeletePlayHistoryAsync(await playHistoryMethods.SearchPlayHistoryAsync(user.UserId, game.GameId));

                // Assert
                Assert.False(result); // result should be false if history was not found
            }
        }
    }
}