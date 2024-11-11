using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using E_commerce.Pages.viewmodelclasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace E_commerce.Pages.userpages
{
    public class UserSignupModel : PageModel
    {

        [BindProperty]
        public ModelUser signuppage { get; set; }

        public readonly DBcontext _context;
        public readonly IWebHostEnvironment Environment;

        public UserSignupModel(DBcontext dbContext, IWebHostEnvironment env)
        {
            _context = dbContext;
            Environment = env;
        }
        public List<SelectListItem> genderoptions { get; set; }
        public void OnGet()
        {
            genderoptions = new List<SelectListItem>
            {
                new SelectListItem{Value="Male",Text="Male"},

                new SelectListItem{Value="Female",Text="Female"}
            };

        }

        public IActionResult Onpost()
        {
            if (!ModelState.IsValid)
            {
                genderoptions = new List<SelectListItem>
                {
                new SelectListItem{Value="Male",Text="Male"},

                new SelectListItem{Value="Female",Text="Female"}
                };
                return Page();
            }
            else
            {
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(signuppage.Image.FileName);

                var filepath = Path.Combine(Environment.WebRootPath, "Images/Users", filename);

                var filestream = new FileStream(filepath, FileMode.Create);
                signuppage.Image.CopyToAsync(filestream);
                filestream.Close();

                var newuser = new user
                {
                    Name = signuppage.Name,
                    PhoneNumber = signuppage.PhoneNumber,
                    Email = signuppage.Email,
                    Address1 = signuppage.Address1,
                    Address2 = signuppage.Address2,
                    pincode1 = signuppage.Pincode1,
                    pincode2 = signuppage.Pincode2,
                    pincode1 = signuppage.pincode1,
                    pincode2 = signuppage.pincode2,
                    Gender = signuppage.Gender,
                    Password = signuppage.Password,
                    ImagePath = filepath
                };

                _context.Users.Add(newuser);
                _context.SaveChanges();
                TempData["message"] = "Signup successful";
                return RedirectToPage("UserLogin");
            }
        }
    }
}
