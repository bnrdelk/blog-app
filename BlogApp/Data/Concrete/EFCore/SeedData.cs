using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data.Concrete.EFCore;

namespace BlogApp.Data.Concrete.EFCore
{
    public static class SeedData
    {
        public static void CreateSeedData(IApplicationBuilder app)
        {
            // get BlogContext
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any()) //if there is pending mig. that doesnt applied to db,
                {
                    context.Database.Migrate();// migrate them to db - apply
                }

                // add seed data -> if there is no data add test data 

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = ".Net" },
                        new Tag { Text = "C#" },
                        new Tag { Text = "Spring" },
                        new Tag { Text = "Java" },
                        new Tag { Text = "ReactJs" }
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "beyzanurdeliktas"},
                        new User { UserName = "johndoe"}
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post {
                            Title = "Asp.Net Core MVC",
                            Content = "Asp.Net Core MVC content",
                            IsPublic = true,
                            PublishTime = DateTime.Now.AddDays(-10), // 10 days ago
                            Tags = context.Tags.Take(3).ToList(), // add tags - first 3
                            UserId = 1
                        },
                        new Post {
                            Title = "Spring Framework",
                            Content = "Spring Framework content",
                            IsPublic = true,
                            PublishTime = DateTime.Now.AddDays(-20), 
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 2
                        },
                        new Post {
                            Title = "Java EE",
                            Content = "Java EE content",
                            IsPublic = true,
                            PublishTime = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}