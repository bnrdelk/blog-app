namespace BlogApp.Entity
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public DateTime PublishTime { get; set; }   
        public bool IsPublic { get; set; }

        // one user
        public int UserId { get; set; }
        public User User { get; set; } = null!; //not null

        // many to many
        public List<Tag> Tags { get; set; } = new List<Tag>();
        // many to one
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}