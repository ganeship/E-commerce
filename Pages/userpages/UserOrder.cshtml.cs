using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Pages.userpages
{
    public class UserOrderModel : PageModel
    {
        private readonly DBcontext _context;

        public UserOrderModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public List<OrderItem> UserOrders { get; set; } = new List<OrderItem>();

        public async Task OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
               
                Response.Redirect("UserLogin");
                return;
            }

            
            UserOrders = await _context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new OrderItem
                {
                    ProductId = o.ProductId,
                    ProductName = o.ProductName,
                    Quantity = o.Quantity,
                    OrderedDate = o.OrderedDate,
                    UserAddress = o.UserAddress
                })
                .ToListAsync();
        }
        public IActionResult OnPostReview()
        {
            return RedirectToPage("Reviews");
        }

        public class OrderItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public DateTime OrderedDate { get; set; }
            public string UserAddress { get; set; }
        }
    }
}
