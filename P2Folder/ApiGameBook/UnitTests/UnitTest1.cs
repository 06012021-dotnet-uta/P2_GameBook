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
                userMethods.CreateUser(user);
                result = playHistoryMethods.CreatePlayHistory(user, game);

                // Assert
                Assert.True(result); // result should be true if creation of a new play history entry was successful
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
                userMethods.CreateUser(user);
                playHistoryMethods.CreatePlayHistory(user, game);
                result = playHistoryMethods.DeletePlayHistory(playHistoryMethods.SearchPlayHistory(user.UserId, game.GameId));

                // Assert
                Assert.True(result); // result should be true if deletion of a play history entry was successful
            }
        }

    }
}
