using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using Xunit;

namespace UnitTests
{
    public class GameRatingMethodsTests
    {

        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb4").Options;

        [Fact]
        public void RateGameNewRatingPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                //Arange

                //return bool
                bool result;
                //needed for method
                int userRating = 5;
                int gameId = 10;
                User user = new()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };

                //the methods we will be using belond to these classes
                GameRatingMethods gameMethods = new GameRatingMethods(context);
                UserMethods userMethods = new UserMethods(context);

                //Act

                //ensure Db's are created and deleted for they are test Db's
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                //creates things need creating
                userMethods.CreateUser(user);
                //runs test
                result = gameMethods.RateGame(user.UserId, gameId, userRating);


                //Assert

                //Asserts ;p
                Assert.True(result);
            }

        }

        [Fact]
        public void RateGameTestupdateRating()
        {
            using (var context = new gamebookdbContext(options))
            {
                //Arange

                //return bool
                bool result;
                //needed for method
                int userRating = 5;
                int trueRating = 10;
                int gameId = 10;
                User user = new()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                //the methods we will be using belond to these classes
                GameRatingMethods gameMethods = new GameRatingMethods(context);
                UserMethods userMethods = new UserMethods(context);

                //Act

                //ensure Db's are created and deleted for they are test Db's
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                //creates things need creating
                userMethods.CreateUser(user);
                gameMethods.RateGame(user.UserId, gameId, userRating);


                //Assert
                result = gameMethods.RateGame(user.UserId, gameId, trueRating);
                //Asserts ;p
                Assert.True(result);
                Assert.Equal(10, trueRating);
            }
        }
        [Fact]
        public void DeleteRatingPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                //Arange

                //return bool
                bool result;
                //needed for method
                int userRating = 5;
                int gameId = 10;
                User user = new()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                //the methods we will be using belond to these classes
                GameRatingMethods gameMethods = new GameRatingMethods(context);
                UserMethods userMethods = new UserMethods(context);

                //Act

                //ensure Db's are created and deleted for they are test Db's
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                //creates things need creating
                userMethods.CreateUser(user);
                gameMethods.RateGame(user.UserId, gameId, userRating);

                //finds rating to delete
                Rating temp = gameMethods.SearchRatings(user.UserId, gameId);

                //runs test
                result = gameMethods.DeleteRating(temp);

                //Asserts
                Assert.True(result);
            }
        }
    }

}
