using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using Xunit;

namespace UnitTests
{
    public class UserMethodsTests
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb3").Options;

        [Fact]
        public void CreateUserPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = userMethods.CreateUser(user);

                // Assert
                Assert.True(result); // result should be true if user create was successful
            }
        }

        [Fact]
        public void CreateUserWithMatchingUsername()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user1 = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                User user2 = new User()
                {
                    Username = "username",
                    FirstName = "first2",
                    LastName = "last2",
                    Email = "email2@email.com"
                };
                UserMethods userMethods = new UserMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user1);
                result = userMethods.CreateUser(user2);

                // Assert
                Assert.False(result); // result should be false if user has matching username
            }
        }

        [Fact]
        public void DeleteUserPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user);
                result = userMethods.DeleteUser(user);

                // Assert
                Assert.True(result); // result is true if delete was successful
            }
        }

        [Fact]
        public void DeleteUserNoUserFound()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = userMethods.DeleteUser(user);

                // Assert
                Assert.False(result); // result should be false if no user is found in database
            }
        }

        [Fact]
        public void SearchUserByUsernamePass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                User result;
                string searchName = "username";
                User user1 = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                User user2 = new User()
                {
                    Username = "username2",
                    FirstName = "first2",
                    LastName = "last2",
                    Email = "email2@email.com"
                };
                UserMethods userMethods = new UserMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user1);
                userMethods.CreateUser(user2);
                result = userMethods.SearchUserByUsername(searchName);

                // Assert
                Assert.NotNull(result); // result is not null if a match is found
            }
        }

        [Fact]
        public void SearchUserByUsernameEmptyString()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                User result;
                string searchName = "";
                User user1 = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                User user2 = new User()
                {
                    Username = "username2",
                    FirstName = "first2",
                    LastName = "last2",
                    Email = "email2@email.com"
                };
                UserMethods userMethods = new UserMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user1);
                userMethods.CreateUser(user2);
                result = userMethods.SearchUserByUsername(searchName);

                // Assert
                Assert.Null(result); // result should be null if search string not provided
            }
        }

        [Fact]
        public void SearchUserByUsernameNullSearchString()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                User result;
                string searchName = null;
                User user1 = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                User user2 = new User()
                {
                    Username = "username2",
                    FirstName = "first2",
                    LastName = "last2",
                    Email = "email2@email.com"
                };
                UserMethods userMethods = new UserMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user1);
                userMethods.CreateUser(user2);
                result = userMethods.SearchUserByUsername(searchName);

                // Assert
                Assert.Null(result); // result should be null if search string not provided
            }
        }

        [Fact]
        public void SearchUserByUsernameNoResults()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                User result;
                string searchName = "username";
                User user1 = new User()
                {
                    Username = "username1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                User user2 = new User()
                {
                    Username = "username2",
                    FirstName = "first2",
                    LastName = "last2",
                    Email = "email2@email.com"
                };
                UserMethods userMethods = new UserMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user1);
                userMethods.CreateUser(user2);
                result = userMethods.SearchUserByUsername(searchName);

                // Assert
                Assert.Null(result); // result is null if no user if found with matching username
            }
        }


    }
}

