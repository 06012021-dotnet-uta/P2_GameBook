using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GameMethods
    {
        private gamebookdbContext _context;

        public GameMethods(gamebookdbContext context)
        {
            _context = context;
        }

        public bool RateGame(User user, Game game, int rating)
		{
			try
			{



				Rating rate = new Rating()
				{
					UserId = user.UserId,
					GameId = game.GameId,
					Rating1 = rating,
					Game = game,
					User = user
				};

				Rating temp = (from x in _context.Ratings
							   where x.GameId == game.GameId &&
							   x.UserId == user.UserId
							   select x).FirstOrDefault();

				if (temp == null)
				{
					_context.Ratings.Add(rate);
					_context.SaveChanges();
					return true;
				}
				else
				{

					_context.Ratings.Update(rate);
					_context.SaveChanges();
					return true;
				}
			}
			catch(SystemException)
			{
				return false;
			}
		}



	}
}
