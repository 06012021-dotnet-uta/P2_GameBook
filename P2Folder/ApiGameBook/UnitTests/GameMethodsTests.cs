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
	public class GameMethodsTests
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
                    GameId = 101,
                    Name = "Halo"
                };
                //the methods we will be using belond to these classes
                GameMethods gameMethods = new GameMethods(context);
                UserMethods userMethods = new UserMethods(context);

                //Act
                
                //ensure Db's are created and deleted for they are test Db's
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                //creates things need creating
                userMethods.CreateUser(user);
                //runs test
                result = gameMethods.RateGame(user, game, userRating);


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
                    GameId = 101,
                    Name = "Halo"
                };
                //the methods we will be using belond to these classes
                GameMethods gameMethods = new GameMethods(context);
                UserMethods userMethods = new UserMethods(context);

                //Act

                //ensure Db's are created and deleted for they are test Db's
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                //creates things need creating
                userMethods.CreateUser(user);
                gameMethods.RateGame(user, game, userRating);


                //Assert
                result = gameMethods.RateGame(user, game, trueRating);
                //Asserts ;p
                Assert.True(result);
            }

        }



    }

}
