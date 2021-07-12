using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using Xunit;

namespace UnitTests
{
    public class FreindMethodsTests
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb").Options;

        [Fact]
        public void CreateFriendPass()
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
                userMethods.CreateUser(user1);
                userMethods.CreateUser(user2);
                result = friendMethods.CreateFriend(userMethods.SearchUserByUsername("user1"), userMethods.SearchUserByUsername("user2"));

                // Assert
                Assert.True(result); // result should be true if friend added was successful
            }
        }

        [Fact]
        public void CreateFriendSameUser()
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
                userMethods.CreateUser(user1);
                result = friendMethods.CreateFriend(userMethods.SearchUserByUsername("user1"), userMethods.SearchUserByUsername("user1"));

                // Assert
                Assert.False(result); // result should be false if user tries to friend itself
            }
        }

        [Fact]
        public void DeleteFriendPass()
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
                userMethods.CreateUser(user1);
                userMethods.CreateUser(user2);
                friendMethods.CreateFriend(user2, user1);
                result = friendMethods.DeleteFriend(friendMethods.SearchFriend(user1.UserId, user2.UserId));

                // Assert
                Assert.True(result); // result should be true if friend delete was successful
            }
        }

        [Fact]
        public void CreateNullFriend()
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
                result = friendMethods.CreateFriend(user1, user2);

                // Assert
                Assert.False(result); // result is false if friend pair is null
            }
        }


        [Fact]
        public void DeleteNullFriend()
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
                result = friendMethods.DeleteFriend(friend);

                // Assert
                Assert.False(result); // result is false if friend pair is null
            }
        }

        [Fact]
        public void DeleteFriendNotFound()
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
                friendMethods.CreateFriend(user1, user2);
                result = friendMethods.DeleteFriend(friend);

                // Assert
                Assert.False(result); // result is false if friend does not exist
            }
        }
    }
}