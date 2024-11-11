using Microsoft.AspNetCore.Http;  // Add this using directive

namespace E_commerce.Pages.viewmodelclasses
{
    public class ModelUser
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int Pincode1 { get; set; }
        public int Pincode2 { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        // Add this property for the image
        public IFormFile Image { get; set; }
    }
}
