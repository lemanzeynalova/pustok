using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Contexts;
using Pustok.ViewModels.SliderVM;

namespace Pustok.ViewComponents;

public class SliderViewComponent: ViewComponent
{
    PustokDbContext _context { get; }

    public SliderViewComponent(PustokDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(await _context.Sliders.Select(s => new SliderListItemVM
        {
            Id = s.Id,
            ImageUrl = s.ImageUrl,
            IsLeft = s.IsLeft,
            Title = s.Title,
            Text = s.Text,
        }).ToListAsync());
    }
}
