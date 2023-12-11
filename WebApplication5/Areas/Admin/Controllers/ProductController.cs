using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Contexts;

namespace Pustok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public ProductController(PustokDbContext db)
        {
            _db = db;
        }

        PustokDbContext _db {  get; set; }  
        public async Task<IActionResult> Index()
        {
           
            return View(await _db.Sliders.ToListAsync());
        }
    }
}
