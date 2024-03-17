using Microsoft.EntityFrameworkCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.EFCore
{
    public class BlogContext: DbContext
    {
        // const for getting connection string 
        // options info comes from program.cs
        public BlogContext(DbContextOptions<BlogContext> options): base(options)
        {
            
        }
        // DbSets for entities :: with migration send them to db 
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();
    }
}