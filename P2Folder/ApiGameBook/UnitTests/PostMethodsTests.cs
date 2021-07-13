using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using Xunit;

namespace UnitTests
{
    public class PostMethodsTests
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb2").Options;
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
                Assert.NotNull(result); // result is not null if creating a post is successfull
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
                Assert.Null(result); // result should be null if post has no content
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
                Assert.Null(result); // result should be null if post has no content
            }
        }

        [Fact]
        public void CreatePostStringTooLong()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                int? result;
                // sorry for this...
                string content = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1";
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
                Assert.Null(result); // result should be null if post content is too long
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
                Assert.True(result); // result should be true if edit content was successful
            }
        }

        [Fact]
        public void EditPostSameContent()
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
                result = userPostingMethods.EditPost(userPostingMethods.SearchPostById(postId), content);

                // Assert
                Assert.False(result); // result should be false if content is the same
            }
        }

        [Fact]
        public void EditPostEmptyString()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                int? postId;
                string content = "test content string";
                string newContent = "";
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
                Assert.False(result); // result should be false if content is empty string
            }
        }

        [Fact]
        public void EditPostNullString()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                int? postId;
                string content = "test content string";
                string newContent = null;
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
                Assert.False(result); // result should be false if content is null string
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
                Assert.True(result); // result should be true if delete was successful
            }
        }

        [Fact]
        public void DeletePostNotFound()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                UserPostingMethods userPostingMethods = new UserPostingMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();

                result = userPostingMethods.DeletePost(1);

                // Assert
                Assert.False(result); // result should be false if post is not found
            }
        }

        [Fact]
        public void CreateCommentPass()
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
                int? parentID = userPostingMethods.CreatePost(userMethods.SearchUserByUsername("username"), content);
                Post parentPost = userPostingMethods.SearchPostById(parentID);
                result = userPostingMethods.CreateComment(userMethods.SearchUserByUsername("username"), content, parentPost);

                // Assert
                Assert.NotNull(result); // result is not null if creating a post is successfull
            }
        }

        [Fact]
        public void CreateCommentNullParent()
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
                int? parentID = userPostingMethods.CreatePost(userMethods.SearchUserByUsername("username"), content);
                Post parentPost = null;
                result = userPostingMethods.CreateComment(userMethods.SearchUserByUsername("username"), content, parentPost);

                // Assert
                Assert.Null(result); // result is null if comment not made
            }
        }
    }
}