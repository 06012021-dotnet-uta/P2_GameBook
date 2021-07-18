using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class Rating
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int Rating1 { get; set; }

        public virtual User User { get; set; }
    }
}
