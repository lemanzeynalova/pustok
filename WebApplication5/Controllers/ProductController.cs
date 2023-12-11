using Microsoft.AspNetCore.Mvc;
using Pustok.Contexts;

namespace Pustok.Controllers
{
    public class ProductController : Controller
    {
        PustokDbContext _db { get; }
        public ProductController(PustokDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
