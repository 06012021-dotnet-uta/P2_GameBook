using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class Keyword
    {
        public Keyword()
        {
            KeywordJunctions = new HashSet<KeywordJunction>();
        }

        public int KeywordId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<KeywordJunction> KeywordJunctions { get; set; }
    }
}
