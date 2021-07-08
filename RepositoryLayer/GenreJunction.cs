using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class GenreJunction
    {
        public int GenreId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
