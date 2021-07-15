using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class FreindMethodsTests
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb").Options;

        [Fact]
        public async Task CreateFriendPassAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user1 = new User()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                User user2 = new User()
                {
                    Username = "user2",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                UserFriendMethods friendMethods = new UserFriendMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                await userMethods .CreateUserAsync(user1);
                await userMethods .CreateUserAsync(user2);
                result = await friendMethods.CreateFriendAsync(await userMethods.SearchUserByUsernameAsync("user1"), await userMethods .SearchUserByUsernameAsync("user2"));

                // Assert
                Assert.True(result); // result should be true if friend added was successful
            }
        }

        [Fact]
        public async Task CreateFriendSameUserAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user1 = new User()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                UserFriendMethods friendMethods = new UserFriendMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                await userMethods .CreateUserAsync(user1);
                result = await friendMethods.CreateFriendAsync(await userMethods.SearchUserByUsernameAsync("user1"), await userMethods.SearchUserByUsernameAsync("user1"));

                // Assert
                Assert.False(result); // result should be false if user tries to friend itself
            }
        }

        [Fact]
        public async Task DeleteFriendPassAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user1 = new User()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                User user2 = new User()
                {
                    Username = "user2",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                UserFriendMethods friendMethods = new UserFriendMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                await userMethods .CreateUserAsync(user1);
                await userMethods .CreateUserAsync(user2);
                await friendMethods .CreateFriendAsync(user2, user1);
                result = await friendMethods.DeleteFriendAsync(await friendMethods.SearchFriendAsync(user1.UserId, user2.UserId));

                // Assert
                Assert.True(result); // result should be true if friend delete was successful
            }
        }

        [Fact]
        public async Task CreateNullFriendAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                User user1 = new User();
                User user2 = new User();
                UserMethods userMethods = new UserMethods(context);
                UserFriendMethods friendMethods = new UserFriendMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = await friendMethods.CreateFriendAsync(user1, user2);

                // Assert
                Assert.False(result); // result is false if friend pair is null
            }
        }


        [Fact]
        public async Task DeleteNullFriendAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                Friend friend = new Friend();
                UserMethods userMethods = new UserMethods(context);
                UserFriendMethods friendMethods = new UserFriendMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                result = await friendMethods.DeleteFriendAsync(friend);

                // Assert
                Assert.False(result); // result is false if friend pair is null
            }
        }

        [Fact]
        public async Task DeleteFriendNotFoundAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                Friend friend = new Friend()
                {
                    User1Id = 100,
                    User2Id = 101
                };
                User user1 = new User()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                User user2 = new User()
                {
                    Username = "user2",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                UserFriendMethods friendMethods = new UserFriendMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                await friendMethods .CreateFriendAsync(user1, user2);
                result = await friendMethods.DeleteFriendAsync(friend);

                // Assert
                Assert.False(result); // result is false if friend does not exist
            }
        }
    }
}