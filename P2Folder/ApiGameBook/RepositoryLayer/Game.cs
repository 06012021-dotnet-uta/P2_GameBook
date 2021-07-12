using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class Game
    {
        public Game()
        {
            CollectionJunctions = new HashSet<CollectionJunction>();
            GenreJunctions = new HashSet<GenreJunction>();
            KeywordJunctions = new HashSet<KeywordJunction>();
            PlayHistories = new HashSet<PlayHistory>();
            Ratings = new HashSet<Rating>();
        }

        public int GameId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CollectionJunction> CollectionJunctions { get; set; }
        public virtual ICollection<GenreJunction> GenreJunctions { get; set; }
        public virtual ICollection<KeywordJunction> KeywordJunctions { get; set; }
        public virtual ICollection<PlayHistory> PlayHistories { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
