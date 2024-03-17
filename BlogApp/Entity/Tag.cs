namespace BlogApp.Entity;

public class Tag
{
    public int TagId { get; set; }
    public string? Text { get; set; }
    // many posts - many to many
    public List<Post> Posts { get; set; } = new List<Post>();
}