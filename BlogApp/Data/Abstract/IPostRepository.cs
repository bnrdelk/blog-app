using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IPostRepository
    {
        // IQueryable extra filtreleme yapabilme imkanı sunuyor
        IQueryable<Post> Posts { get; }

        void CreatePost(Post post);
    }
}