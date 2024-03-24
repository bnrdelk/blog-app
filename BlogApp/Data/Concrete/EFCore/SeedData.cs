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
                        new Tag { Text = ".Net", Url="dotnet", Color = TagColors.primary},
                        new Tag { Text = "C#" , Url="c#", Color = TagColors.danger},
                        new Tag { Text = "Spring" , Url="spring", Color = TagColors.warning},
                        new Tag { Text = "Java" , Url="java", Color = TagColors.success},
                        new Tag { Text = "ReactJs", Url="reactjs", Color = TagColors.secondary}
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "beyzanurdeliktas", Image="female.jpg" },
                        new User { UserName = "johndoe", Image="male.jpg" }
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post {
                            Title = "Asp.Net Core MVC",
                            Content = "Asp.Net Core MVC content",
                            Url="asp-net-core",
                            IsPublic = true,
                            Image = "2.png",
                            PublishTime = DateTime.Now.AddDays(-10), // 10 days ago
                            Tags = context.Tags.Take(3).ToList(), // add tags - first 3
                            UserId = 1,
                            Comments = new List<Comment> {
                                 new Comment{Text = "Awesome, keep going on!", PublishTime = new DateTime(), UserId = 2},
                                 new Comment{Text = "Thanks!", PublishTime = new DateTime(), UserId = 1}
                                  }
                        },
                        new Post {
                            Title = "Spring Framework",
                            Content = "Spring Framework content",
                            Url="spring-framework",
                            IsPublic = true,
                            Image = "1.png",
                            PublishTime = DateTime.Now.AddDays(-20), 
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 2
                        },
                        new Post {
                            Title = "Java EE",
                            Content = "Java EE content",
                            Url="java-ee",
                            IsPublic = true,
                            Image = "3.webp",
                            PublishTime = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        },
                        new Post {
                            Title = "C# Language",
                            Content = "C# Language content",
                            Url="c#-language",
                            IsPublic = true,
                            Image = "3.webp",
                            PublishTime = DateTime.Now.AddDays(-9),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        },
                        new Post {
                            Title = "ReactJS Framework",
                            Content = "ReactJS Framework content",
                            Url="reactjs-framework",
                            IsPublic = true,
                            Image = "2.webp",
                            PublishTime = DateTime.Now.AddDays(-1),
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