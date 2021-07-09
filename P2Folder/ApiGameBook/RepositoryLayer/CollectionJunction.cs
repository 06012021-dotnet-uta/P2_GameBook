using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class CollectionJunction
    {
        public int CollectionId { get; set; }
        public int GameId { get; set; }

        public virtual Collection Collection { get; set; }
        public virtual Game Game { get; set; }
    }
}
