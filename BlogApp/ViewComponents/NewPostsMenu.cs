using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class NewPostsMenu: ViewComponent
    {
        public IPostRepository _postRepository;

        public NewPostsMenu(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(
                await _postRepository
                .Posts
                .OrderByDescending(p => p.PublishTime)
                .Take(5)
                .ToListAsync()
            );
        }
    }
}