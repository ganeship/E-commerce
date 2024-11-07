using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace E_commerce.Pages.viewmodelclasses
{
    public class ModelProducts
    {

        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }

        [Required]
        public string SubCategory { get; set; }


        [Required, NotNull]
        public string Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int IsActive { get; set; } = 1;

        public IFormFile Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? Image3 { get; set; }
        public IFormFile? Image4 { get; set; }
    }
}
