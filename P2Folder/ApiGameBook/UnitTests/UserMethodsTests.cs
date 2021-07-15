using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class UserMethodsTests
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb3").Options;

        [Fact]
        public async Task CreateUserPassAsync()
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
                result = await userMethods.CreateUserAsync(user);

                // Assert
                Assert.True(result); // result should be true if user create was successful
            }
        }

        [Fact]
        public async Task CreateUserWithMatchingUsernameAsync()
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
                await userMethods .CreateUserAsync(user1);
                result = await userMethods.CreateUserAsync(user2);

                // Assert
                Assert.False(result); // result should be false if user has matching username
            }
        }

        [Fact]
        public async Task DeleteUserPassAsync()
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
                await userMethods .CreateUserAsync(user);
                result = await userMethods.DeleteUserAsync(user);

                // Assert
                Assert.True(result); // result is true if delete was successful
            }
        }

        [Fact]
        public async Task DeleteUserNoUserFoundAsync()
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
                result = await userMethods.DeleteUserAsync(user);

                // Assert
                Assert.False(result); // result should be false if no user is found in database
            }
        }

        [Fact]
        public async Task SearchUserByUsernamePassAsync()
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
                await userMethods.CreateUserAsync(user1);
                await userMethods.CreateUserAsync(user2);
                result = await userMethods.SearchUserByUsernameAsync(searchName);

                // Assert
                Assert.NotNull(result); // result is not null if a match is found
            }
        }

        [Fact]
        public async Task SearchUserByUsernameEmptyStringAsync()
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
                await userMethods.CreateUserAsync(user1);
                await userMethods.CreateUserAsync(user2);
                result = await userMethods.SearchUserByUsernameAsync(searchName);

                // Assert
                Assert.Null(result); // result should be null if search string not provided
            }
        }

        [Fact]
        public async Task SearchUserByUsernameNullSearchStringAsync()
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
                await userMethods .CreateUserAsync(user1);
                await userMethods .CreateUserAsync(user2);
                result = await userMethods.SearchUserByUsernameAsync(searchName);

                // Assert
                Assert.Null(result); // result should be null if search string not provided
            }
        }

        [Fact]
        public async Task SearchUserByUsernameNoResultsAsync()
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
                await userMethods .CreateUserAsync(user1);
                await userMethods .CreateUserAsync(user2);
                result = await userMethods.SearchUserByUsernameAsync(searchName);

                // Assert
                Assert.Null(result); // result is null if no user if found with matching username
            }
        }
        [Fact]
        public async Task EditUserPassAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User oldUser = new User()
                {
                    Username = "username1",
                    Password = "1234",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                User newUser = new User()
                {
                    Username = "username2",
                    Password = "1234",
                    FirstName = "first2",
                    LastName = "last2",
                    Email = "email2@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                await userMethods.CreateUserAsync(oldUser);
                result = await userMethods.EditUserAsync(oldUser, newUser);

                // Assert
                Assert.True(result); // result should be true if user edit passed
                Assert.NotNull(userMethods.SearchUserByUsernameAsync(newUser.Username)); // result should be not null if edited user exist in database
            }
        }

    }
}

