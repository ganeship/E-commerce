using System.ComponentModel.DataAnnotations;

namespace E_commerce.Pages.viewmodelclasses
{
    public class ModelPayment
    {
        [Required]
        public string PaymentId { get; set; }
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public String Status { get; set; }

        [Required]
        public DateTime OrderedDate { get; set; }
    }
}
