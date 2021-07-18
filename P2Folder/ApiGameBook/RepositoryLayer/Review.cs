using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class Review
    {
        public int GameId { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
