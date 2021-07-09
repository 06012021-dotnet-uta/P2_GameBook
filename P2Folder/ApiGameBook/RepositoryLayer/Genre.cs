using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class Genre
    {
        public Genre()
        {
            GenreJunctions = new HashSet<GenreJunction>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GenreJunction> GenreJunctions { get; set; }
    }
}
