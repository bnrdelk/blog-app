using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ICommentRepository
    {
        // IQueryable extra filtreleme yapabilme imkanı sunuyor
        IQueryable<Comment> Comments { get; }

        void CreateComment(Comment comment);
    }
}