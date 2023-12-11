using System.ComponentModel.DataAnnotations;

namespace Pustok.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int ParentId { get; set; }
    }
}
