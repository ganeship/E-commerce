﻿using System.ComponentModel.DataAnnotations;

namespace E_commerce.Data.Entity
{
    public class cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }    
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
