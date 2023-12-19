using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.ColorVM
{
    public class ColorCreateVM
    {
        [Required, MaxLength(32)]
        public string Name { get; set; }
        [Required, MaxLength(7), MinLength(7)]
        public string Hexcode { get; set; }
    }
}
