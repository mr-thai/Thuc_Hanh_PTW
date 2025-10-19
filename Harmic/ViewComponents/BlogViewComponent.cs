using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harmic.Models; 

namespace Harmic.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly Th2Context _context;

        public BlogViewComponent(Th2Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take = 5)
        {
            var blogs = await _context.TbBlogs
                .OrderByDescending(b => b.CreatedDate)
                .Take(take)
                .ToListAsync();

            return View(blogs); 
        }
    }
}
