using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class Collection
    {
        public Collection()
        {
            CollectionJunctions = new HashSet<CollectionJunction>();
        }

        public int CollectionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CollectionJunction> CollectionJunctions { get; set; }
    }
}
