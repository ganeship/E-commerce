 namespace E_commerce.Data.Entity
{
    public class review
    {
        public int reviewId { get; set; }
        public int userId { get; set; } 
        public int productId { get; set; } 
        public int rating { get; set; } 
        public DateTime reviewDate { get; set; } 

        
        public user user { get; set; }
        public product product { get; set; }
        public string comments { get; set; }
    }
}
