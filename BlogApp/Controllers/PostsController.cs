using Microsoft.AspNetCore.Mvc;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EFCore;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class PostsController: Controller 
    {
        // Injection
        private IPostRepository _postRepository;
        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<IActionResult> Index(string url)
        {
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
                                .Include(p => p.Comments)
                                .ThenInclude(p => p.User)//her gitmis oldugun commentin userına git (gidip tkerar sorgu yaptıgından dolayı then)
                                .FirstOrDefaultAsync(p => p.Url == url));
        }
    }
}