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
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb").Options;

        [Fact]
        public void RateGameTestNewRating()
        {
            using (var context = new gamebookdbContext(options))
			{
                //Arange


                bool result;
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

           
                GameMethods gameMethods = new GameMethods(context);
                UserMethods userMethods = new UserMethods(context);


                //Act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                userMethods.CreateUser(user);
                result = gameMethods.RateGame(user, game, userRating);


                //Assert
                Assert.True(result);
            }
        }

    }
}
