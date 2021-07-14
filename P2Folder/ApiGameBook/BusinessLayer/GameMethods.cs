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
		/// <summary>
		/// This will either do the initial rating or update a rating
		/// </summary>
		/// <param name="user">Tracks user who rates</param>
		/// <param name="game">Tracks the game to be rated</param>
		/// <param name="rating">Tracks the rating for the game by user</param>
		/// <returns>Only returns false if something terrible happens</returns>
        public bool RateGame(User user, Game game, int rating)
		{
			try
			{
				//fills the object rate with everything it needs
				Rating rate = new Rating()
				{
					UserId = user.UserId,
					GameId = game.GameId,
					Rating1 = rating,
					Game = game,
					User = user
				};
				//checks if this user already rated said game
				Rating temp = (from x in _context.Ratings
							   where x.GameId == game.GameId &&
							   x.UserId == user.UserId
							   select x).FirstOrDefault();
				//if the user hasn't it will create a new rating
				if (temp == null)
				{
					_context.Ratings.Add(rate);
					_context.SaveChanges();
					return true;
				}
				else
				{
					temp.Rating1 = rating;
					//else it will updayte the rating
					_context.Ratings.Update(temp);
					_context.SaveChanges();
					return true;
				}
			}
			//if for some reason the crash happens it wil just return false
			catch(SystemException)
			{
				return false;
			}
		}



	}
}
