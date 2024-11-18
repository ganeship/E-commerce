using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace E_commerce.Data.Entity
{
    public class product
    {
        [Key]
        public int Id { get; set; }

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

        public string ImagePath1 { get; set; }
        public string? ImagePath2 { get; set; }
        public string? ImagePath3 { get; set; }
        public string? ImagePath4 { get; set; }

        public int SellerId { get; set; } = 0;
    
    }
}
