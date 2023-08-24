using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CourseManagementWeb.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        [Required]
        public string Username { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            
            if (Username == "admin" && Password =="123")
            {
                return RedirectToPage("/Celendar/Index");

            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid email or password.";
                return Page();
            }

            return Page();
        }
    }
}