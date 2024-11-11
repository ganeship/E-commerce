using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;  // Add this using directive

namespace E_commerce.Pages.viewmodelclasses
{
    public class ModelUser
    {
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required,MaxLength(15),MinLength(6)]
        public string Password { get; set; }

        [Required,MaxLength(15), MinLength(6)]

        public string ConfirmPassword {  get; set; }

        public IFormFile? Image { get; set; }

        [Required]
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public int Pincode1 { get; set; }
        public int Pincode2 { get; set; }
        // Add this property for the image
        public string Address1 { get; set; }

        [Range(100000, 999999)]
        public int pincode1 { get; set; }

        public string? Address2 { get; set; }

        [Range(100000, 999999)]
        public int? pincode2 { get; set; }
    }
}
