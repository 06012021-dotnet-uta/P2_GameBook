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
        public void RateGameTestNewRating()
        {
            using (var context = new gamebookdbContext(options))
            {
                //Arange

                //return bool
                bool result;
                //needed for method
                int userRating = 5;
                User user = new()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                Game game = new()
                {
                    Name = "Halo"
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
                context.Games.Add(game);
                //runs test
                result = gameMethods.RateGame(user.UserId, game.GameId, userRating);


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
                User user = new()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                Game game = new()
                {
                    Name = "Halo"
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
                context.Games.Add(game);
                gameMethods.RateGame(user.UserId, game.GameId, userRating);


                //Assert
                result = gameMethods.RateGame(user.UserId, game.GameId, trueRating);
                //Asserts ;p
                Assert.True(result);
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
                User user = new()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                Game game = new()
                {
                    Name = "Halo"
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
                context.Games.Add(game);
                gameMethods.RateGame(user.UserId, game.GameId, userRating);

                //finds rating to delete
                Rating temp = (from x in context.Ratings
                               where x.GameId == game.GameId &&
                               x.UserId == user.UserId
                               select x).FirstOrDefault();

                //runs test
                result = gameMethods.DeleteRating(temp);

                //Asserts
                Assert.True(result);
            }
        }

        [Fact]
        public void DeleteNonExistantRatingPass()
        {
            using (var context = new gamebookdbContext(options))
            {
                //Arange

                //return bool
                bool result;
                //needed for method
                int userRating = 5;
                User user = new()
                {
                    Username = "user1",
                    FirstName = "first",
                    LastName = "last",
                    Email = "email@email.com"
                };
                Game game = new()
                {
                    Name = "Halo"
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
                context.Games.Add(game);
                gameMethods.RateGame(user.UserId, game.GameId, userRating);

                //finds rating to delete
                Rating temp = (from x in context.Ratings
                               where x.GameId == 2 &&
                               x.UserId == 2
                               select x).FirstOrDefault();

                //runs test
                result = gameMethods.DeleteRating(temp);

                //Asserts
                Assert.False(result);
            }

        }

    }

}
