using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class KeywordJunction
    {
        public int KeywordId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Keyword Keyword { get; set; }
    }
}
