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
        public IActionResult Index()
        {
            return View(
                new PostsViewModel 
                {
                    Posts = _postRepository.Posts.ToList(),
                }
            );
        }

        public async Task<IActionResult> Details(int? id)
        {

            return View(await _postRepository
                                .Posts
                                .FirstOrDefaultAsync(p => p.PostId == id));
        }
    }
}