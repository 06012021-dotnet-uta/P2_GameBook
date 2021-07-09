using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class Friend
    {
        public int User1Id { get; set; }
        public int User2Id { get; set; }

        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
