using RepositoryLayer;

namespace BusinessLayer
{
    public interface IGameRatingMethods
    {
        bool DeleteRating(Rating rating);
        bool RateGame(int user, int game, int rating);
        Rating SearchRatings(int userid, int gameid);
    }
}