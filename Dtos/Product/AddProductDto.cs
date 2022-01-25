using System.ComponentModel.DataAnnotations;

namespace challenge.Dtos.Product
{
    public class AddProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
