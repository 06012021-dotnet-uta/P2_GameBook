using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class PlayHistory
    {
        public int UserId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
