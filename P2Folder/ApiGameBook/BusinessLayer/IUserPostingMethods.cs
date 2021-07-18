using System.Collections.Generic;
using RepositoryLayer;

namespace BusinessLayer
{
    public interface IUserPostingMethods
    {
        int? CreateComment(User user, string content, Post parent);
        int? CreatePost(User user, string content);
        bool DeletePost(int? postId);
        bool EditPost(Post post, string newContent);
        Post SearchPostById(int? postId);
        List<int> PostsList();
    }
}