using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages.userpages
{
    public class UserLoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }


        public user currentuser { get; set; }

        private readonly DBcontext dbcontext;

        public UserLoginModel(DBcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        
        public void OnGet()
        {

        }
        public IActionResult OnPostLogin()

        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Email or password fields is missing");
                return Page();
            }
            currentuser = dbcontext.Users.Where(p=> p.Email == Email ).FirstOrDefault();

            if(currentuser != null)
            {
                if(currentuser.Password==Password)
                {
                    HttpContext.Session.SetInt32("UserId",  currentuser.Id);
                    HttpContext.Session.SetString("UserName", currentuser.Name);
                    return RedirectToPage("UserHome");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Password is incorrect.");
                    return Page();

                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email does not exist. Please sign up.");
                return Page();
            }
        }
    }
}
