using System.ComponentModel.DataAnnotations;

namespace E_commerce.Pages.viewmodelclasses
{
    public class ModelSeller
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        [Required,MaxLength(15),MinLength(6)]
        public string Password {  get; set; }
        
        [Required,MaxLength(15),MinLength(6)]
        public string PasswordConfirmed {  get; set; }

        [Required]
        public string Address { get; set; }

        [Required, MaxLength(6)] public string PinCode { get; set; }

        [Required]
        public string? ShopName { get; set; }
    }


}
