using Microsoft.AspNetCore.Mvc;

namespace Pustok.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
