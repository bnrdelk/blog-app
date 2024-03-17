namespace BlogApp.Entity;

public class Comment
{
    public int CommentId { get; set; }
    public string? Text { get; set; }
    public DateTime PublishTime { get; set; }

    // to one post
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;

    // from one user
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}