using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.SliderVM;

public class SliderCreateVM
{
    public string ImageUrl { get; set; }
    [Required, MinLength(3), MaxLength(64), DataType("nvarchar")]
    public string Title { get; set; }
    [Required, MinLength(3), MaxLength(128), DataType("varchar")]
    public string Text { get; set; }
    public byte Position { get; set; }
}
