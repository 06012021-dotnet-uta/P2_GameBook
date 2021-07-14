using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GameRatingMethods
    {
        private gamebookdbContext _context;

        public GameRatingMethods(gamebookdbContext context)
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
        public bool RateGame(int user, int game, int rating)
		{
			//never question MALIA 
			if (rating > 10 || rating < 0) 
			{
				return false;
			}
			try
			{
				//fills the object rate with everything it needs
				Rating rate = new Rating()
				{
					UserId = user,
					GameId = game,
					Rating1 = rating
				};
				//checks if this user already rated said game
				Rating temp = (from x in _context.Ratings
							   where x.GameId == game &&
							   x.UserId == user
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

	/// <summary>
	/// Allows the ability to delete rating
	/// </summary>
	/// <param name="rating">Takes the rating to delete</param>
	/// <returns>Returns true on success</returns>
	public bool DeleteRating(Rating rating)
	{
		bool success = false;

		try
		{
			//check if user exists in database
			if (rating == null)
			{
				Console.WriteLine("Rating connot be null");
				return success;
			}
			else
			{
				// delete user from db, change success to true if successful
				_context.Ratings.Remove(rating);
				_context.SaveChanges();
				success = true;
				return success;
			}
		}
		catch
		{
			Console.WriteLine("Error, rating not deleted");
		}

		return success;
	}


	}
}
