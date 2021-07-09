using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb").Options;

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
                Assert.True(result);
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
                Assert.False(result);
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
                Assert.True(result);
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
                Assert.NotNull(result);
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
                Assert.Null(result);
            }
        }

        [Fact]
        public void CreatePostPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                int? result;
                string content = "demo content to test";
                User user = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPostingMethods userPostingMethods = new UserPostingMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user);
                result = userPostingMethods.CreatePost(userMethods.SearchUserByUsername("username"), content);

                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void CreatePostEmptyString()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                int? result;
                string content = "";
                User user = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPostingMethods userPostingMethods = new UserPostingMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user);
                result = userPostingMethods.CreatePost(userMethods.SearchUserByUsername("username"), content);

                // Assert
                Assert.Null(result);
            }
        }

        [Fact]
        public void CreatePostNullString()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                int? result;
                string content = null;
                User user = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPostingMethods userPostingMethods = new UserPostingMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user);
                result = userPostingMethods.CreatePost(userMethods.SearchUserByUsername("username"), content);

                // Assert
                Assert.Null(result);
            }
        }

        [Fact]
        public void EditPostPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                int? postId;
                string content = "test content string";
                string newContent = "new string";
                User user = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPostingMethods userPostingMethods = new UserPostingMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user);
                postId = userPostingMethods.CreatePost(userMethods.SearchUserByUsername("username"), content);
                result = userPostingMethods.EditPost(userPostingMethods.SearchPostById(postId), newContent);

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public void DeletePostPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                int? postId;
                string content = "test content string";
                User user = new User()
                {
                    Username = "username",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                UserMethods userMethods = new UserMethods(context);
                UserPostingMethods userPostingMethods = new UserPostingMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user);
                postId = userPostingMethods.CreatePost(userMethods.SearchUserByUsername("username"), content);
                result = userPostingMethods.DeletePost(postId);

                // Assert
                Assert.True(result); 
            }
        }
    }
}
