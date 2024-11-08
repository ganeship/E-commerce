using System.ComponentModel.DataAnnotations;

namespace E_commerce.Data.Entity
{
    public class user
    {
       [Key] public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        
        public string? ImagePath { get; set; }

        [Required]
        public string Gender { get; set; }

        public string? Address1 {  get; set; }

        [Range(100000,999999)]
        public int? pincode1 { get; set; }

        public string? Address2 {  get; set; }

        [Range(100000, 999999)]
        public int? pincode2 { get; set; }

        public bool isactive { get; set; } = true;

    }
}
