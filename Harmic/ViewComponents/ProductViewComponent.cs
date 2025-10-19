using Harmic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Harmic.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly Th2Context _context;
        public ProductViewComponent(Th2Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            var items = _context.TbProducts.Include(x => x.CategoryProduct)
                .Where(x => (bool)x.IsActive).Where(m=> m.IsNew);
            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m=>m.ProductId).ToList()));
        }
    }
}
