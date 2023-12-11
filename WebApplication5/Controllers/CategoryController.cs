using Microsoft.AspNetCore.Mvc;

namespace Pustok.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
