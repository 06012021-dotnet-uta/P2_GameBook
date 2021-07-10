using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserPlayHistoryMethods
    {
        private gamebookdbContext _context;

        public UserPlayHistoryMethods(gamebookdbContext context)
        {
            _context = context;
        }
        // Create play history
        public bool CreatePlayHistory(User user, Game game)
        {
            bool success = false;
            try
            {
                PlayHistory history = new PlayHistory()
                {
                    UserId = user.UserId,
                    GameId = game.GameId,
                };
                _context.PlayHistories.Add(history);
                _context.SaveChanges();
                success = true;
                return success;
            }
            catch
            {
                Console.WriteLine("Error, play history not added");
            }


            return success;
        }
        public bool DeletePlayHistory(PlayHistory history)
        {
            bool success = false;
            try
            {
                _context.Remove(history);
                _context.SaveChanges();
                success = true;
                return success;
            }
            catch
            {
                Console.WriteLine("Error, play hisotry not removed");
            }
            return success;
        }
        public PlayHistory SearchPlayHistory(int userid, int gameid)
        {
            PlayHistory temp = null;
            temp = _context.PlayHistories.Where(x => (x.UserId == userid && x.GameId == gameid) ).FirstOrDefault();
            return temp;
        }
    }
}
