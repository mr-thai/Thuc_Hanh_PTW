using Microsoft.AspNetCore.Mvc;
using Harmic.Models;
using System.Linq;


namespace Harmic.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly Th2Context _context;
        public MenuTopViewComponent(Th2Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where(x => (bool)x.IsActive).OrderBy(x => x.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
