using Pustok.Areas.Admin.ViewModel;
using Pustok.ViewModels.CommonVM;
using Pustok.ViewModels.SliderVM;

namespace Pustok.ViewModels.HomeVM
{
    public class HomeVM
    {
        public IEnumerable<SliderListItemVM> Sliders { get; set; }
        public IEnumerable<AdminProductListItemVM> Products { get; set; }
        public PaginatonVM<IEnumerable<AdminProductListItemVM>> PaginatedProducts { get; set; }
    }
}
