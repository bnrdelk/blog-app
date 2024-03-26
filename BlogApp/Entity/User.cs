namespace BlogApp.Entity;

public class User
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Image { get; set; }
    // one to many
    public List<Post> Posts { get; set; } = new List<Post>(); //initilazed 
   // one to many
    public List<Comment> Comments { get; set; } = new List<Comment>(); //initilazed 
}