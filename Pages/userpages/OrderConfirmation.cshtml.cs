using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages.userpages
{
    public class OrderConfirmationModel : PageModel
    {
        public string OrderId { get; set; }

        // The OnGet method will be triggered when the page is accessed
        public void OnGet()
        {
            // Retrieve the OrderId from the session (as set in Checkout)
            OrderId = HttpContext.Session.GetString("OrderId");

            // If there is no OrderId in the session, you can handle it accordingly, like redirecting or showing an error.
            if (string.IsNullOrEmpty(OrderId))
            {
                // Redirect to another page (e.g., Home or an error page) if the order ID isn't found
                RedirectToPage("/Error");
            }
        }
    }
}
