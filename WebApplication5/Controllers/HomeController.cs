using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pustok.Contexts;
using Pustok.Models;
using Pustok.ViewModels.SliderVM;
using System.Reflection;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(PustokDbContext db)
        {
            _db = db;
        }

        PustokDbContext _db {  get; set; }
        public async Task<IActionResult> Index()
        {
            
            var sliders = await _db.Sliders.ToListAsync();
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
            _db.Sliders.Select(s=>new SliderListItemVM
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
        public async Task<IActionResult> Create(SliderCreateVM vm)
        {
            if (vm.Position<-1|| vm.Position>1)
            {
                ModelState.AddModelError("Position", "wrong input");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            
            Slider slider = new Slider()
            {
                Title = vm.Title,
                Text = vm.Text,
                ImageUrl = vm.ImageUrl,
                IsLeft = vm.Position switch
                {
                    0 => null,
                    -1 => true,
                    1 => false
                }
            };
            await _db.Sliders.AddAsync(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            TempData["Response"] = false;
            if (id == null) return BadRequest();
           
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) RedirectToAction(nameof(Index));
            _db.Sliders.Remove(data);
            await _db.SaveChangesAsync();
            TempData["Response"] = true;
            return RedirectToAction(nameof(Index));
        }
        
    }
}
