using System.ComponentModel.DataAnnotations;

namespace E_commerce.Data.Entity
{
    public class order
    {
        [Key]
       public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required] 
        public int UserId{ get; set; }

        [Required]
        public string UserAddress { get; set; }

        [Required]
        public DateTime OrderedDate { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
