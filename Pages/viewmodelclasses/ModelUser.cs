using Microsoft.AspNetCore.Http;  // Add this using directive

namespace E_commerce.Pages.viewmodelclasses
{
    public class ModelUser
    {
        public string Name { get; set; }
<<<<<<< HEAD
=======

        [Required]
        public string Email { get; set; }

        [Required,MaxLength(15),MinLength(6)]
        public string Password { get; set; }

        [Required,MaxLength(15), MinLength(6)]

        public string ConfirmPassword {  get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public IFormFile? Image { get; set; }

        [Required]
>>>>>>> 0313c721f06a385fb2a48d0b4532bad64b9443f6
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int Pincode1 { get; set; }
        public int Pincode2 { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

<<<<<<< HEAD
        // Add this property for the image
        public IFormFile Image { get; set; }
=======
        public string Address1 { get; set; }

        [Range(100000, 999999)]
        public int pincode1 { get; set; }

        public string? Address2 { get; set; }

        [Range(100000, 999999)]
        public int? pincode2 { get; set; }
>>>>>>> 0313c721f06a385fb2a48d0b4532bad64b9443f6
    }
}
