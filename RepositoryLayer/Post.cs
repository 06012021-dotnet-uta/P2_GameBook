using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class Post
    {
        public Post()
        {
            InverseCommentParent = new HashSet<Post>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public int? CommentParentId { get; set; }
        public string Content { get; set; }
        public int? Rating { get; set; }
        public DateTime PostDate { get; set; }

        public virtual Post CommentParent { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Post> InverseCommentParent { get; set; }
    }
}
