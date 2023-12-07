using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pustok.Contexts;
using Pustok.Models;
using Pustok.ViewModels.SliderVM;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using PustokDbContext db = new PustokDbContext();
            var sliders = await db.sliders.ToListAsync();
            List<SliderListItemVM> items = new List<SliderListItemVM>();
            foreach(var sItem in sliders)
            {
                items.Add(new SliderListItemVM
                {
                    Id=sItem.Id,
                    ImageUrl = sItem.ImageUrl,
                    IsLeft = sItem.IsLeft,
                    Text = sItem.Text,
                    Title = sItem.Title,
                });
            }
            db.sliders.Select(s=>new SliderListItemVM
            {
                Title = s.Title,
                Text = s.Text,
                IsLeft= s.IsLeft,
                ImageUrl= s.ImageUrl,
                Id=s.Id,
            });
            return View(items);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if(!ModelState.IsValid)
            {
                return View(slider);
            }
            using PustokDbContext dbContext = new PustokDbContext();
            await dbContext.sliders.AddAsync(slider);
            await dbContext.SaveChangesAsync();
            return View();
        }
    }
}
