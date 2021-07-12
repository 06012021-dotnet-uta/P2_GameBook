using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using Xunit;

namespace UnitTests
{
    public class PlayHistoryMethodsTests
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb1").Options;

        [Fact]
        public void CreatePlayHistoryPass()
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
                userMethods.CreateUser(user);
                result = playHistoryMethods.CreatePlayHistory(user, game);

                // Assert
                Assert.True(result); // result should be true if creation of a new play history entry was successful
            }
        }

        [Fact]
        public void CreatePlayHistoryGameNotFound()
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
                userMethods.CreateUser(user);
                result = playHistoryMethods.CreatePlayHistory(user, game);

                // Assert
                Assert.False(result); // result should be false if game not found in db
            }
        }

        [Fact]
        public void CreatePlayHistoryUserNotFound()
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
                result = playHistoryMethods.CreatePlayHistory(user, game);

                // Assert
                Assert.False(result); // result should be false if user not found in db
            }
        }

        [Fact]
        public void DeletePlayHistoryPass()
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
                userMethods.CreateUser(user);
                playHistoryMethods.CreatePlayHistory(user, game);
                result = playHistoryMethods.DeletePlayHistory(playHistoryMethods.SearchPlayHistory(user.UserId, game.GameId));

                // Assert
                Assert.True(result); // result should be true if deletion of a play history entry was successful
            }
        }

        [Fact]
        public void DeletePlayHistoryNotFound()
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
                userMethods.CreateUser(user);
                result = playHistoryMethods.DeletePlayHistory(playHistoryMethods.SearchPlayHistory(user.UserId, game.GameId));

                // Assert
                Assert.False(result); // result should be false if history was not found
            }
        }
    }
}