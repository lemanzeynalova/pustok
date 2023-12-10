using Microsoft.AspNetCore.Mvc;
using Pustok.Contexts;

namespace Pustok.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (PustokDbContext pd = new PustokDbContext())
            {
                var items = await pd.Categories.Select(c => new CategoryListItemVM
                {
                    Name = c.Name,
                    Id = c.Id,
                    IsDeleted = c.IsDeleted,
                    ParentId = c.ParentId,

                }).ToListAsync();
                return View(items);
            }
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
