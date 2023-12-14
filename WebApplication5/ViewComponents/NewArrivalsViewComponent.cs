using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Areas.Admin.ViewModel;
using Pustok.Contexts;

namespace Pustok.ViewComponents
{
    public class NewArrivalsViewComponent: ViewComponent
    {
        PustokDbContext _context { get; }

        public NewArrivalsViewComponent(PustokDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Products.Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Id)
                .Take(6)
                .Select(p => new AdminProductListItemVM
                {
                    Category = p.Category,
                    Name = p.Name,
                    Discount = p.Discount,
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    SellPrice = p.SellPrice,
                }).ToListAsync()
            );
        }
        //public IViewComponentResult Invoke()
        //{
        //    return View();
        //}
    }
}

