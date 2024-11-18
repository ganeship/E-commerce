using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce.Pages.userpages
{
    public class ReviewsModel : PageModel
    {
        private readonly DBcontext _context;

        public List<product> OrderedProducts { get; set; } = new List<product>(); 
        public Dictionary<int, ReviewDetails> UserReviews { get; set; } = new Dictionary<int, ReviewDetails>();
        public HashSet<int> UserReviewedProducts { get; set; } = new HashSet<int>();

        public ReviewsModel(DBcontext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var productId = HttpContext.Session.GetInt32("ProductId");

            if (userId == null)
            {
                RedirectToPage("UserLogin"); 
                return;
            }

            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
            var orderedProductIds = orders.Select(o => o.ProductId).Distinct();

           
            OrderedProducts = _context.Products
                .Where(p => orderedProductIds.Contains(p.ProductId))
                .ToList();

            foreach (var product in OrderedProducts)
            {
                var review = _context.Reviews
                    .FirstOrDefault(r => r.productId == product.ProductId && r.userId == userId);

                if (review != null)
                {
                    UserReviews[product.ProductId] = new ReviewDetails
                    {
                        Rating = review.rating,
                        Comments = review.comments
                    };
                    UserReviewedProducts.Add(product.ProductId);
                }
            }
        }

        public IActionResult OnPostAddReview(int productId, int rating, string comments)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToPage("UserLogin"); 
            }

            var existingReview = _context.Reviews
                .FirstOrDefault(r => r.productId == productId && r.userId == userId);

            if (existingReview != null)
            {
                existingReview.rating = rating;
                existingReview.comments = comments;
            }
            else
            {
                var newReview = new review
                {
                    productId = productId,
                    userId = userId.Value, 
                    rating = rating,
                    comments = comments,
                    reviewDate = System.DateTime.Now
                };
                _context.Reviews.Add(newReview);
            }

            _context.SaveChanges();
            return RedirectToPage(); 
        }

        public class ReviewDetails
        {
            public int Rating { get; set; }
            public string Comments { get; set; }
        }
    }
}
