using System.ComponentModel.DataAnnotations;

namespace E_commerce.Pages.viewmodelclasses
{
    public class ModelCart
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
