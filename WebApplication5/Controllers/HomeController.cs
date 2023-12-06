using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Contexts;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using PustokDbContext context = new PustokDbContext();
            var sliders= await context.sliders.ToListAsync();
            return View(sliders);
        }
    }
}
