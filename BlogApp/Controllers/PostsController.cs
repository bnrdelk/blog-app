using Microsoft.AspNetCore.Mvc;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EFCore;
using BlogApp.Models;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    public class PostsController: Controller 
    {
        // Injection
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }
        public async Task<IActionResult> Index(string url)
        {
            var claims = User.Claims;
            var posts = _postRepository.Posts;

            if(!string.IsNullOrEmpty(url))
            {
                posts = posts.Where(p => p.Tags.Any(t => t.Url == url));
            }
            return View(
                new PostsViewModel 
                {
                    Posts = await posts.ToListAsync()
                }
            );
        }

        public async Task<IActionResult> Details(string url)
        {

            return View(await _postRepository
                                .Posts
                                .Include(p => p.Tags)
                                .Include(p => p.Comments)
                                .ThenInclude(p => p.User)//her gitmis oldugun commentin userına git (gidip tkerar sorgu yaptıgından dolayı then)
                                .FirstOrDefaultAsync(p => p.Url == url));
        }

        public IActionResult AddComment(int PostId, string Text, string Url)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // NameIdentifier = Id 
            var username = User.FindFirstValue(ClaimTypes.Name);
            var profilepic = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment {
                Text = Text,
                PublishTime = DateTime.Now,
                PostId = PostId,
                // şimdilik yeni user oluşturulacak
                UserId = int.Parse(userId ?? "")
            };
             _commentRepository.CreateComment(entity);

            return Redirect("/posts/details/" + Url);
        }
         
    }
}