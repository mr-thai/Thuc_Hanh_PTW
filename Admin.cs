using Microsoft.AspNetCore.Mvc;

namespace Harmic
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
