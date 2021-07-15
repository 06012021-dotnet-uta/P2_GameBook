using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class PostMethodsTests
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb2").Options;
        [Fact]

        public async Task CreatePostPassAsync()
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
                await userMethods.CreateUserAsync(user);
                result = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);

                // Assert
                Assert.NotNull(result); // result is not null if creating a post is successfull
            }
        }

        [Fact]
        public async Task CreatePostEmptyStringAsync()
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
                await userMethods.CreateUserAsync(user);
                result = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);

                // Assert
                Assert.Null(result); // result should be null if post has no content
            }
        }

        [Fact]
        public async Task CreatePostNullStringAsync()
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
                await userMethods .CreateUserAsync(user);
                result = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);

                // Assert
                Assert.Null(result); // result should be null if post has no content
            }
        }

        [Fact]
        public async Task CreatePostStringTooLongAsync()
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
                await userMethods.CreateUserAsync(user);
                result = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);

                // Assert
                Assert.Null(result); // result should be null if post content is too long
            }
        }

        [Fact]
        public async Task EditPostPassAsync()
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
                await userMethods.CreateUserAsync(user);
                postId = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);
                result = await userPostingMethods.EditPostAsync(await userPostingMethods.SearchPostByIdAsync(postId), newContent);

                // Assert
                Assert.True(result); // result should be true if edit content was successful
            }
        }

        [Fact]
        public async Task EditPostSameContentAsync()
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
                await userMethods.CreateUserAsync(user);
                postId = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);
                result = await userPostingMethods.EditPostAsync(await userPostingMethods.SearchPostByIdAsync(postId), content);

                // Assert
                Assert.False(result); // result should be false if content is the same
            }
        }

        [Fact]
        public async Task EditPostEmptyStringAsync()
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
                await userMethods .CreateUserAsync(user);
                postId = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);
                result = await userPostingMethods.EditPostAsync(await userPostingMethods.SearchPostByIdAsync(postId), newContent);

                // Assert
                Assert.False(result); // result should be false if content is empty string
            }
        }

        [Fact]
        public async Task EditPostNullStringAsync()
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
                await userMethods .CreateUserAsync(user);
                postId = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);
                result = await userPostingMethods.EditPostAsync(await userPostingMethods.SearchPostByIdAsync(postId), newContent);

                // Assert
                Assert.False(result); // result should be false if content is null string
            }
        }

        [Fact]
        public async Task DeletePostPassAsync()
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
                await userMethods .CreateUserAsync(user);
                postId = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);
                result = await userPostingMethods.DeletePostAsync(postId);

                // Assert
                Assert.True(result); // result should be true if delete was successful
            }
        }

        [Fact]
        public async Task DeletePostNotFoundAsync()
        {
            using (var context = new gamebookdbContext(options))
            {
                // Arrange
                bool result;
                UserPostingMethods userPostingMethods = new UserPostingMethods(context);

                // Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();

                result = await userPostingMethods.DeletePostAsync(1);

                // Assert
                Assert.False(result); // result should be false if post is not found
            }
        }

        [Fact]
        public async Task CreateCommentPassAsync()
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
                await userMethods.CreateUserAsync(user);
                int? parentID = await userPostingMethods.CreatePostAsync(await userMethods.SearchUserByUsernameAsync("username"), content);
                Post parentPost = await userPostingMethods.SearchPostByIdAsync(parentID);
                result = await userPostingMethods.CreateCommentAsync(await userMethods .SearchUserByUsernameAsync("username"), content, parentPost);

                // Assert
                Assert.NotNull(result); // result is not null if creating a post is successfull
            }
        }

        [Fact]
        public async Task CreateCommentNullParentAsync()
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
                await userMethods .CreateUserAsync(user);
                int? parentID = await userPostingMethods.CreatePostAsync(await userMethods .SearchUserByUsernameAsync("username"), content);
                Post parentPost = null;
                result = await userPostingMethods.CreateCommentAsync(await userMethods.SearchUserByUsernameAsync("username"), content, parentPost);

                // Assert
                Assert.Null(result); // result is null if comment not made
            }
        }
    }
}