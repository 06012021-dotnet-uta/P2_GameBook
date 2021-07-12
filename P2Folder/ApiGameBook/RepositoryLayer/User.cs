using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer
{
    public partial class User
    {
        public User()
        {
            FriendUser1s = new HashSet<Friend>();
            FriendUser2s = new HashSet<Friend>();
            PlayHistories = new HashSet<PlayHistory>();
            Posts = new HashSet<Post>();
            Ratings = new HashSet<Rating>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Friend> FriendUser1s { get; set; }
        public virtual ICollection<Friend> FriendUser2s { get; set; }
        public virtual ICollection<PlayHistory> PlayHistories { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
