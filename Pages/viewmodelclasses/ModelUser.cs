using System.ComponentModel.DataAnnotations;

namespace E_commerce.Pages.viewmodelclasses
{
    public class ModelUser
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required,MaxLength(15),MinLength(6)]
        public string Password { get; set; }

        [Required,MaxLength(15), MinLength(6)]

        public string ConfirmPassword {  get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? ImagePath { get; set; }

        [Required]
        public string Gender { get; set; }

        public string? Address1 { get; set; }

        [MaxLength(6)]
        public int? pincode1 { get; set; }

        public string? Address2 { get; set; }

        [MaxLength(6)]
        public int? pincode2 { get; set; }
    }
}
