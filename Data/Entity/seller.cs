using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Data.Entity
{
    public class seller
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required,MaxLength(6)] public int PinCode { get; set; }

        [Required]
        public string? ShopName { get; set; }

        [Required]
        public bool IsVerified {  get; set; }=false;
    }
}
