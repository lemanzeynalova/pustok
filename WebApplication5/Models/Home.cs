using System.ComponentModel.DataAnnotations;

namespace Pustok.Models
{
    public class Home
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required, MinLength(5), MaxLength(64)]
        public string Title { get; set; }
        [Required, MinLength(5), MaxLength(64)]
        public string Description { get; set; }
        public bool IsLeft { get; set; }
    }
}
